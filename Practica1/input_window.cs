﻿using System;
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
        System.Timers.Timer _GlobalTimer;
        bool stop = false;
        int h, m, s;
        private const int _count = 4;
        public input_window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _GlobalTimer = new System.Timers.Timer();
            _GlobalTimer.Interval = 1000;
            _GlobalTimer.Elapsed += OnTimeEvent;

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
                timeTxt.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }
            ));
        }

        private void addBtn(object sender, EventArgs e)
        {
            //Aquí les recomiendo que hagan la parte de validación y la parte de agregar los procesos a la cola de procesos
        }

        private void input_window_FormClosed(object sender, FormClosedEventArgs e)
        {
            _GlobalTimer.Stop();
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
            Queue<Proceso> _Procesos = new Queue<Proceso>();//Se crea la lista de procesos
            Queue<GroupBox> _display_options_used = new Queue<GroupBox>();//Se crea la lista para las barras en uso
            Queue<GroupBox> _display_options = new Queue<GroupBox>();//Se crea la lista para las opciones de barras
            FillList(_Procesos);
            // Se meten las barras de la UI a una cola 
            #region Agrupamiento de Barras 
            //
            //Se agregan las 4 opciones a la cola
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
                    reSize(_display_options_used.ElementAt(i), _Procesos.ElementAt(i).TimeMax * 10);
                    if(i == _count-1)
                    {
                        break;
                    }
                }
            #endregion
                // Se verifica que el numero de procesos sea igual al numero de procesos deseado, esto se tiene que modificar
                //eventualmente
                while (_display_options_used.Count != 0)//Se verifica que todavia tenemos procesos en la cola
                {   
                    if (stop)//Validamos que se necesita seguir con la ejecución 
                    {
                        break;
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
                            Thread.Sleep(100);//Para motivos de pruebas lo tengo en 100 pero deberia ser 1000 <---
                        });
                    }//Si si se termino la quitamos tanto en la lista de los procesos como en la cola de las barras
                    else
                    {
                        //Pasar a otra lista primero
                        _display_options_used.ElementAt(0).BackColor = Color.DimGray;
                        _display_options_used.Dequeue();
                        _Procesos.Dequeue();
                    }
                    #endregion
                }
                //Se detiene el reloj del procesos
            }
            //Se detiene el global
            _GlobalTimer.Stop();
        }

        private void startBtn(object sender, EventArgs e)//Boton de comienzo
        {
            // Se comienzan tanto el moviemieto de las barras como en reloj
            Thread _ThreadProcesses = new Thread(new ThreadStart(FCFSSchedulling));
            _ThreadProcesses.Start();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
