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
        System.Timers.Timer t;
        bool stop = false;
        int h, m, s;
        private const int _count = 4;
        public input_window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)//Esta es la parte del reloj
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
                txtTiempo.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));



            }
            ));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void input_window_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Stop();
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
        private void FillList(List<Proceso> _Procesos) // Se añaden procesos a una lista
        {
            //Esta parte debera ser reemplazada llenando la lista de procesos con los datos capturados
            Random random = new Random();
            for (int i = 0; i < _count; i++)
            {
                _Procesos.Add(new Proceso());
                _Procesos[i].TimeMax = random.Next(10, 20);
            }
            

        }
        private async void FCFSSchedulling()
        {
            List<Proceso> _Procesos = new List<Proceso>();//Se crea la lista de procesos
            Queue<GroupBox> _groupBoxes = new Queue<GroupBox>();
            FillList(_Procesos);
            // Se meten las barras de la UI a una cola 
            #region Agrupamiento de Barras 
            _groupBoxes.Enqueue(groupBox1);
            _groupBoxes.Enqueue(groupBox2);
            _groupBoxes.Enqueue(groupBox3);
            _groupBoxes.Enqueue(groupBox4);
            for(int i=0; i<_count; i++)// Se ajustan los tamaños de las barras
            {
                reSize(_groupBoxes.ElementAt(i), _Procesos[i].TimeMax * 10);
            }
                

            #endregion
            // Se verifica que el numero de procesos sea igual al numero de procesos deseado, esto se tiene que modificar
            //eventualmente
            if (_Procesos.Count == _count)
            {

                //Esta vairable nos permite iterar sobre los distintos procesos
                int x = 0;

                while (_groupBoxes.Count != 0)//Se verifica que todavia tenemos procesos en la cola
                {
                    //if (x < _groupBoxes.Count)
                    //{
                    //    reSize(_groupBoxes.ElementAt(x), _Procesos[x].TimeMax * 10);
                    //    x++;
                    //}

                    if (stop)//Validamos que se necesita seguir con la ejecución 
                    {
                        break;
                    }
                    #region Datos de Proceso
                    //Esta es la parte donde eventualmente vamos a modificar los labels
                    // if (_Procesos.Count > 0)
                    //{
                    //    setText(LNameFCFS, "Nombre Proceso FCFS:" + _Procesos.First().Name);


                    //}
                    

                    #endregion

                    #region EstiloDeBarras


                    //No se proque puse dos de estos ifs jaja
                    //if (stop)
                    //{
                    //    break;
                    //}
                    if (_groupBoxes.First().Size.Height > 10)//Verificamos que la barra actual no se haya "Terminado"
                    {
                        _groupBoxes.First().BackColor = Color.Red;//El proceso actual se pone en rojo
                        if (_groupBoxes.Count > 1)
                        {
                            // Si hay más de un proceso por terminar entonces se pone a el siguiente en azul
                            _groupBoxes.ElementAt(1).BackColor = Color.Blue;
                        }
                        //Se ajusta el tamaño de la barra, disminuyendo la altura
                        reSize(_groupBoxes.First(), _groupBoxes.First().Size.Height - 10);
                        //Aquí ajustamos cada cuanto queremos que se espere nuestro planificador
                        await Task.Run(() =>
                        {
                            Thread.Sleep(1000);
                        });



                    }//Si si se termino la quitamos tanto en la lista de los procesos como en la cola de las barras
                    else
                    {
                        _groupBoxes.Dequeue();
                        _Procesos.Remove(_Procesos.First());
                    }
                    #endregion
                }
                t.Stop();//Se detiene el reloj
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error al cargar los procesos");
            }
            Console.WriteLine("jajaja");
        }

        private void button2_Click(object sender, EventArgs e)//Boton de comienzo
        {
            // Se comienzan tanto el moviemieto de las barras como en reloj
            Thread pBar1 = new Thread(new ThreadStart(FCFSSchedulling));
            pBar1.Start();
            t.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
