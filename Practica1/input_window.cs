using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;



namespace Practica1
{
    public partial class input_window : Form
    {
        Queue<Proceso> _Procesos = new Queue<Proceso>();
        System.Timers.Timer _GlobalTimer;
        Queue<Label> labelsUsed = new Queue<Label>();
        int contLabelToBeUsed = 0;
        bool processStart = true;
        bool stop = true;
        int h, m, s;
        private const int _count = 4;
        public input_window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _GlobalTimer = new System.Timers.Timer();
            _GlobalTimer.Elapsed += new System.Timers.ElapsedEventHandler(_GlobalTimer_Elapsed);
            _GlobalTimer.Interval = 100;   //here you can set your interval

        }
        
        void _GlobalTimer_Elapsed(object sender, ElapsedEventArgs e)//Esta es la parte del reloj
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if(s==60)
                {
                    s = 0;
                    m += 1;
                }
                else if(m==60)
                {
                    m = 0;
                    h += 1;
                }
                timeTxt.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }
            ));
        }
        
        private void addBtn(object sender, EventArgs e)
        {
            Proceso newProcess = new Proceso();

            newProcess.Name = textBoxProgrammerName.Text;
            newProcess.TimeMax = int.Parse(textBoxTimeMax.Text);
            newProcess.opName = textBoxOp.Text;
            newProcess.id = textBoxId.Text;
            _Procesos.Enqueue(newProcess);
            //Aquí les recomiendo que hagan la parte de validación y la parte de agregar los procesos a la cola de procesos
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
        private void FillList(Queue<Proceso> _Processes) // Se añaden procesos a una lista
        {
            //Esta parte se debera quitar en algun momento
            Random random = new Random();
            var max = random.Next(10, 20);
            for (int i = 0; i < max; i++)
            {
                _Processes.Enqueue(new Proceso());
                _Processes.ElementAt(i).TimeMax = random.Next(10, 20);      //.First.TimeMax = random.Next(10, 20);
            }
            

        }
        private async void FCFSSchedulling()
        {
            //Se crea la lista de procesos
            Queue<GroupBox> _display_options_used = new Queue<GroupBox>();//Se crea la lista para las barras en uso
            Queue<GroupBox> _display_options = new Queue<GroupBox>();//Se crea la lista para las opciones de barras
            int initialValue = 0;
            //FillList(_Procesos);
            stop = false;
            // Se meten las barras de la UI a una cola 
            #region Agrupamiento de Barras 
            //
            //Se agregan las 4 opciones a la cola
            labelsUsed.Enqueue(labelId);
            labelsUsed.Enqueue(labelOperation);
            labelsUsed.Enqueue(labelProgrammerName);
        
            _display_options.Enqueue(groupBox1);
            _display_options.Enqueue(groupBox2);
            _display_options.Enqueue(groupBox3);
            _display_options.Enqueue(groupBox4);
            //Comienza el timer global, no sé si estaria mejor en otra parte :/
            _GlobalTimer.Start();
            while (_Procesos.Count !=0)
            {
                for(int i=0; i<_Procesos.Count; i++)// Se ajustan los tamaños de las barras dependiendo de cuantas necesitemos
                {
                    _display_options_used.Enqueue(_display_options.ElementAt(i));
                    reSize(_display_options_used.ElementAt(i), _Procesos.ElementAt(i).TimeMax * 10+10);
                    
                    if (i == _count-1)
                    {
                        break;
                    }
                }
            #endregion
                // Se verifica que el numero de procesos sea igual al numero de procesos deseado, esto se tiene que modificar
                //eventualmente
                while (_display_options_used.Count != 0)//Se verifica que todavia tenemos procesos en la cola
                {
                    if(processStart)

                    {
                        contLabelToBeUsed = 0;
                        ProcessInfo(_Procesos.ElementAt(0).id);
                        contLabelToBeUsed = 1;
                        ProcessInfo(_Procesos.ElementAt(0).opName);
                        contLabelToBeUsed = 2;
                        ProcessInfo(_Procesos.ElementAt(0).Name);
                        initialValue = _Procesos.ElementAt(0).TimeMax;
                        processStart = false;
                    }
                    
                    #region Datos de Proceso
                    //Esta es la parte donde eventualmente vamos a modificar los labels(Por hacer)
                    // if (_Processes.Count > 0)
                    //{
                    //    setText(LNameFCFS, "Nombre Proceso FCFS:" + _Processes.First().Name);
                    //}
                    #endregion

                    #region EstiloDeBarras

                    if (_display_options_used.First().Size.Height > 10)//Verificamos que la barra actual no se haya "Terminado"
                    {
                        _display_options_used.First().BackColor = Color.Red;//El proceso actual se pone en rojo



                        if (_display_options_used.Count > 1)
                        {
                            // Si hay más de un proceso por terminar entonces se pone a el siguiente en azul
                            _display_options_used.ElementAt(1).BackColor = Color.Blue;
                        }
                        //Se ajusta el tamaño de la barra, disminuyendo la altura
                        reSize(_display_options_used.First(), _display_options_used.First().Size.Height - 10);
                        //Aquí ajustamos cada cuanto queremos que se espere nuestro planificador
                        await Task.Run(() =>
                        {
                            Thread.Sleep(100);
                            initialValue--;
                            SetText(initialValue.ToString());
                            //Para motivos de pruebas lo tengo en 100 pero deberia ser 1000 <---
                        });
                    }//Si si se termino la quitamos tanto en la lista de los procesos como en la cola de las barras
                    else
                    {
                        //Pasar a otra lista primero
                       
                        _display_options_used.ElementAt(0).BackColor = Color.DimGray;
                        _display_options_used.Dequeue();
                        _Procesos.Dequeue();
                        processStart = true;
                        
                        
                    }
                    #endregion
                }
                if (_Procesos.Count == 0)//Validamos que se necesita seguir con la ejecución 
                {
                    stop = true;
                    break;
                }
                //Se detiene el reloj del procesos
            }
            stop = true;
            //Se detiene el global
            _GlobalTimer.Stop();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startBtn(object sender, EventArgs e)//Boton de comienzo
        {
            // Se comienzan tanto el moviemieto de las barras como en reloj
            if(stop)
            {
                Thread _ThreadProcesses = new Thread(new ThreadStart(FCFSSchedulling));
                _ThreadProcesses.Start();
                //Thread setProcessTimer = new Thread(new ThreadStart(processTimerset));
                
            }
            
            
            
        }
        delegate void SetTextCallback(string text);
        delegate void ProcessInfoCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
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

        private void ProcessInfo(string text) //Función para cambiar los datos de cualquier label, sin tener qué hacer una por cada label.
        {

            

            if (this.InvokeRequired)
            {
                ProcessInfoCallback d = new ProcessInfoCallback(ProcessInfo);
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

        private void processTimerset()
        {
            //processTimertxt.Text = initialValue.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
