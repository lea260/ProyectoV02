using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Modelo;
using Negocio.Objetos;


namespace Presentacion.Formularios
{
    public partial class Chat : Form
    {
        System.Timers.Timer t;
        public Chat()
        {
            InitializeComponent();
            InitChat();
            ActualizarListaChat();
        }
        private void InitChat()
        {
            //
            List<DataChat> list = null;
            Mensaje chat = new Mensaje();
            list = chat.ObtenerMensajes(1);
            string mensaje= "vacio";
            //llenar listbox.
            lstChat.Items.Add("inicio");
            t = new System.Timers.Timer();

            t.AutoReset = true;

            // Start the timer
            t.Enabled = true;

            t.Interval = 1000;//1s
            t.Elapsed += On_TimeEvent;

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //t.Stop();
            string text = txtMensaje.Text;
            if (!string.IsNullOrEmpty(text))
            {
                lstChat.Items.Add(text);
                lstChat.SelectedIndex = lstChat.Items.Count - 1;
            }           
        }


        private void listChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        /*private void Chat_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;//1s
            t.Elapsed += On_TimeEvent;
        }*/
        private void ActualizarListaChat()
        {
            List<DataChat> list = null;
            Mensaje chat = new Mensaje();
            list = chat.ObtenerMensajes(1);
            foreach (DataChat item in list)
            {
                string text = item.Nombre + ": " + item.Mensaje;
                lstChat.Items.Add(text);
                lstChat.SelectedIndex = lstChat.Items.Count - 1;
            }
        }
        




        private void On_TimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            string hola= "hola";
            ActualizarListaChat();
        }
    }
}
 