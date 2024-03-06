using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Practica 3


namespace Practica1
{
    public partial class input_window : Form
    {
        // Variables para tiempos
        DateTime tiempoLlegada;
        DateTime tiempoFinalizacion;
        DateTime tiempoDePrimeraAtencion;

        Queue<Proceso> _Procesos = new Queue<Proceso>();//Se crea la lista de procesos
        Queue<Proceso> _lotes = new Queue<Proceso>();
        Queue<GroupBox> _display_options = new Queue<GroupBox>();//Se crea la lista para las opciones de barras
        Queue<GroupBox> _display_options_used = new Queue<GroupBox>();//Se crea la lista para las barras en uso
       
        int longProcess = 0;
        Queue<Label> labelsUsed = new Queue<Label>();
        int contLabelToBeUsed = 0;
        bool processStart = true;
        bool stop = true;
        bool interrupcion = false;
        bool error = false;
        int h, m, s;
        private const int _count = 3;
        public input_window()
        {
            InitializeComponent();
        }
        public enum _labelsUsedEnum : int //Enum que corresponde a los labels que utilizamos en la cola de los labels
        {
            id,
            operation,
            programmerName,
            lotesOutput,
            time,

            blocked1,
            blocked2,
            blocked3,
            timerProcc
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _display_options.Enqueue(groupBox1);
            _display_options.Enqueue(groupBox2);
            _display_options.Enqueue(groupBox3);
            //_display_options.Enqueue(groupBox4);
            foreach(GroupBox box in  _display_options)
            {
                reSize(box, 15 * 10 + 10);
            }
            
            //Se agregan las 4 opciones a la cola
            labelsUsed.Enqueue(labelId);
            labelsUsed.Enqueue(labelOperation);
            labelsUsed.Enqueue(labelProgrammerName);
            labelsUsed.Enqueue(_contLotesOutput);
            labelsUsed.Enqueue(timeTxt);
            
            labelsUsed.Enqueue(blockedTimer1);
            labelsUsed.Enqueue(blockedTimer2);
            labelsUsed.Enqueue(blockedTimer3);
            labelsUsed.Enqueue(processTimertxt);
            
            //labelsUsed.Enqueue(labelProcesosInput);


        }

        //Contador global
        void globalTimer()
        {
            s += 1;
            if (s == 60)
            {
                s = 0;
                m += 1;
            }
            else if (m == 60)
            {
                m = 0;
                h += 1;
            }
        }

      
        //Funcion para hacer operaciones dentro de un string
        public static string Evaluate(string expression)
        {
            
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return (string)row["expression"];
            
            

        }

        private void input_window_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.DoEvents();
        }
        private void reSize(GroupBox b, int amount)//Funcion para cambiar el tamaño de las barras
        {
            
            b.Invoke((MethodInvoker)(() => b.Size = new Size(b.Size.Width, amount)));
            
        }
        private void setText(Label l, String s)//Funcion para facilitar los ajustes de los labels
        {
            l.Invoke((MethodInvoker)(() => l.Text = s));

        }
        private void FillList() // Se añaden procesos a una lista
        {
            //Esta parte se debera quitar en algun momento
            Random random = new Random();
            var max = random.Next(7, 18);

            const String _operaciones = "+-/*";
            

            for (int i = 0; i < max; i++)
            {
                _Procesos.Enqueue(new Proceso());
                _Procesos.ElementAt(i).TimeMax = random.Next(7, 18);
                _Procesos.ElementAt(i).id = i.ToString();
                _Procesos.ElementAt(i).opName = ""+random.Next(0, 100) + _operaciones[random.Next(0, 3)] + random.Next(0, 100);
                
                 
                

            }


        }
        // Define un delegado para actualizar el texto del label
        delegate void SetLabelTextDelegate(Label label, string text);

        // Método para actualizar el texto del label de forma segura
        private void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new SetLabelTextDelegate(SetLabelText), label, text);
            }
            else
            {
                label.Text = text;
            }
        }
        private async void FCFSSchedulling()
        {        
            int initialValue = 0;
            Queue<int> blocked = new Queue<int>();
            stop = false;
            // Llegada de un nuevo proceso
            #region Ejecución de procesos
            FillList();
            while (_Procesos.Count != 0)
            {

                for (int i = 0; i < _Procesos.Count; i++)// Se ajustan los tamaños de las barras dependiendo de cuantas necesitemos
                {
                    
                    _display_options_used.Enqueue(_display_options.ElementAt(i));
                    _lotes.Enqueue(_Procesos.ElementAt(i));
                   
                    if (_Procesos.ElementAt(i).TimeMax > 15)
                    {
                        //longProcess = true;
                        reSize(_display_options_used.ElementAt(i),15 * 10 + 10);
                    }
                    else
                    {
                        reSize(_display_options_used.ElementAt(i), _Procesos.ElementAt(i).TimeMax * 10 + 10);
                    }
                    if(i!=0)
                    {
                        _display_options_used.ElementAt(i).BackColor = Color.LimeGreen;
                    }

                    if (i == _count - 1)
                    {
                        break;
                    }
                }

                #endregion
                changeLabel(_Procesos.Count.ToString(), _labelsUsedEnum.lotesOutput);
                
                // Se verifica que el numero de procesos sea igual al numero de procesos deseado, esto se tiene que modificar
                //eventualmente
                while (_display_options_used.Count != 0)//Se verifica que todavia tenemos procesos en la cola
                {
                    if (processStart)
                    {
                        tiempoLlegada = DateTime.Now;
                        SetLabelText(labelLlegadaTxt, tiempoLlegada.ToString());
                        
                        // Se asigna el tiempo de primera atención
                        if (initialValue == 0) { tiempoDePrimeraAtencion = tiempoLlegada; }

                        initialValue = setNewProcess(initialValue);
                        SetText(initialValue.ToString());
                        processStart = false;
                    }

                    if (interrupcion)
                    {
                        _lotes.Enqueue(_lotes.Dequeue());
                        _lotes.Last().TimeMax = initialValue;
                        initialValue = setNewProcess(initialValue);
                        _display_options_used.ElementAt(0).BackColor = Color.LightCoral;
                        _display_options_used.Enqueue(_display_options_used.Dequeue());
                        
                       
                        processStart = true;
                        interrupcion = false;
                       
                    }
                    if (error)
                    {
                        _display_options_used.ElementAt(0).BackColor = Color.DimGray;
                        _display_options_used.Dequeue();
                        _lotes.ElementAt(0).id = "Terminado por error";
                        SetList(_lotes.Dequeue());
                        _Procesos.Dequeue();
                        error = false;
                        processStart = true;
                        if(_display_options_used.Count ==0)
                        {
                            break;
                        }

                    }
                    tiempoFinalizacion = DateTime.Now;
                    SetLabelText(labelFinalizacionTxt, tiempoFinalizacion.ToString());

                    TimeSpan tiempoRetorno = (tiempoFinalizacion - tiempoLlegada);
                    SetLabelText(labelRetornoTxt, tiempoRetorno.ToString());

                    DateTime tiempoRespuesta = tiempoLlegada.Subtract(tiempoRetorno);
                    SetLabelText(labelRespuestaTxt, tiempoRespuesta.ToString("ss.ff"));

                   

                    //TimeSpan tiempoEspera = (tiempoRetorno - tiempoServicio);


                    #region EstiloDeBarras

                    if (_display_options_used.First().Size.Height > 10)//Verificamos que la barra actual no se haya "Terminado"
                    {
                        _display_options_used.First().BackColor = Color.Aquamarine;//El proceso actual se pone en aquamarine


                        
                        //Se ajusta el tamaño de la barra, disminuyendo la altura
                        reSize(_display_options_used.First(), _display_options_used.First().Size.Height - 10);
                        //Aquí ajustamos cada cuanto queremos que se espere nuestro planificador
                        await Task.Run(() =>
                        {
                            Thread.Sleep(100);
                            globalTimer();
                            initialValue--;
                            changeLabel(string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')), _labelsUsedEnum.time);
                            changeLabel(initialValue.ToString(), _labelsUsedEnum.timerProcc);
                           
                           
                            //Para motivos de pruebas lo tengo en 100 pero deberia ser 1000 <---
                        });
                        
                    }//Si si se termino la quitamos tanto en la lista de los procesos como en la cola de las barras
                    else
                    {
                        //Pasar a otra lista primero
                        if(longProcess>1)
                        {
                            longProcess--;
                            if (initialValue > 15)
                            {
                                reSize(_display_options_used.ElementAt(0), 15 * 10 + 10);
                                
                            }
                            else
                            {
                                reSize(_display_options_used.ElementAt(0), initialValue * 10 + 10);
                            }
                        }
                        else
                        {

                            _display_options_used.ElementAt(0).BackColor = Color.DimGray;
                            SetList(_lotes.Dequeue());
                            if (_Procesos.Count!=0)
                            {
                                _lotes.Enqueue(_Procesos.Dequeue());
                                _display_options_used.Enqueue(_display_options_used.Dequeue());
                                if (_lotes.Last().TimeMax > 15)
                                {
                                    //longProcess = true;
                                    reSize(_display_options_used.Last(), 15 * 10 + 10);
                                }
                                else
                                {
                                    reSize(_display_options_used.Last(), _lotes.Last().TimeMax * 10 + 10);
                                }
                                
                                _display_options_used.Last().BackColor = Color.LimeGreen;
                                
                            }
                            else
                            {
                                _display_options_used.Dequeue();
                                
                            }
                            
                            changeLabel(_Procesos.Count.ToString(), _labelsUsedEnum.lotesOutput);

                            processStart = true;
                        }
                        
                    }
                    
                    while (stop)
                    {

                    }
                    
                    #endregion
                }
                
                if (_Procesos.Count == 0)//Validamos que se necesita seguir con la ejecución 
                {
                    // Finalización del proceso
                    // Calcular tiempos
                    //tiempoRetorno = tiempoFinalizacion - tiempoLlegada;
                    //tiempoRespuesta = tiempoLlegada - tiempoRespuesta;
                    //tiempoEspera = tiempoRetorno - tiempoServicio;
                    stop = true;
                    break;
                }

            }
            
            
            stop = true;
            

        }
        //Funcion para cambiar los labels
        private void changeLabel(string newtext,_labelsUsedEnum toBeChanged)
        {
            contLabelToBeUsed = (int)toBeChanged;
            processInfo(newtext);
        }
        //Funcion para cambiar los labels cuando de cambia de proceso
        private int setNewProcess(int initialValue)
        {
            changeLabel(_lotes.ElementAt(0).id, _labelsUsedEnum.id);
            changeLabel(_lotes.ElementAt(0).opName, _labelsUsedEnum.operation);
            initialValue = _lotes.ElementAt(0).TimeMax;
            longProcess = initialValue / 15 + 1;
            changeLabel(initialValue.ToString(), _labelsUsedEnum.timerProcc);
            return initialValue;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startBtn(object sender, EventArgs e)//Boton de comienzo
        {
            // Se comienzan tanto el moviemieto de las barras como en reloj
            if(stop)
            {
                //Se resetea el reloj global
                h = 0;
                s = 0;
                m = 0;
                Thread _ThreadProcesses = new Thread(new ThreadStart(FCFSSchedulling));
                reSize(_display_options.ElementAt(0), 150);
                reSize(_display_options.ElementAt(1), 150);
                reSize(_display_options.ElementAt(2), 150);
                //reSize(_display_options.ElementAt(3), 150);
                ClearList();
                _ThreadProcesses.Start();
               
                //Thread setProcessTimer = new Thread(new ThreadStart(processTimerset));

            }
            
            
            
        }
        delegate void SetTextCallback(string text);
        delegate void SetListCallback(Proceso text);
        delegate void ClearListCallback();
        delegate void ProcessInfoCallback(string text);

        private void ClearList()
        {
            
            if (this.listViewPastProcesses.InvokeRequired)
            {
                ClearListCallback d = new ClearListCallback(ClearList);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.listViewPastProcesses.Items.Clear();
            }
        }
        private void SetText(string text)
        {
            
            if (this.processTimertxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.processTimertxt.Text = text;
            }
        }
        //funcion para cambiar el ViewList de los procesos anteriores
        private void SetList(Proceso proceso)
        {
            
            if (this.listViewPastProcesses.InvokeRequired)
            {
                SetListCallback d = new SetListCallback(SetList);
                this.Invoke(d, new object[] { proceso });
            }
            else
            {
                ListViewItem newItem = new ListViewItem(proceso.id, proceso.opName);
                if(proceso.opName == "Terminado por error")
                {
                    newItem.SubItems.Add(proceso.opName);
                }
                else
                {
                    newItem.SubItems.Add(proceso.opName + "= " + Evaluate(proceso.opName));
                }
                
                newItem.SubItems.Add(proceso.TimeMax.ToString());
                listViewPastProcesses.Items.Add(newItem);
            }
        }


        private void processInfo(string text) //Función para cambiar los datos de cualquier label, sin tener qué hacer una por cada label.
        {

            

            if (this.InvokeRequired)
            {
                ProcessInfoCallback d = new ProcessInfoCallback(processInfo);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                
                labelsUsed.ElementAt(contLabelToBeUsed).Text = text;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void input_window_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.P)
            {
                System.Console.WriteLine(" "+ e.KeyChar);
                stop = true;
            }
            else if(e.KeyChar == (char)Keys.C)
            {
                System.Console.WriteLine(" " + e.KeyChar);
                stop = false;
            }
            else if (e.KeyChar == (char)Keys.I)
            {
                System.Console.WriteLine(" " + e.KeyChar);
                interrupcion = true;
                
            }
            else if (e.KeyChar == (char)Keys.E)
            {
                System.Console.WriteLine(" " + e.KeyChar);
                error = true;
            }
        }

        private void tabPage2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            System.Console.WriteLine("Hola");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void processTimerset()
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
