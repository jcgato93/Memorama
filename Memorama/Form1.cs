using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memorama
{
    public partial class Form1 : Form
    {
        int contador_igual = 0;
        int    elegida=0;
        int jugadas = 0;
        int oportunidades = 3;
        int conta_acertada = 0;
        int[] asignadas = new int[5];
        PictureBox[] seleccionado = new PictureBox[5];
        Bitmap[] select=new Bitmap[2];
        Bitmap[] img = new Bitmap[5];
        Bitmap[] posicion = new Bitmap[9];
        Random asignar = new Random();
        Bitmap xdefexto = new Bitmap(Memorama.Properties.Resources.imgdefault);
        public Form1()
        {
            InitializeComponent();
        }
        
/////////////////////// METODOS///////////////////////////////////////////////////////////

        public void revolver_cartas() //Reorganiza las posiciones de las imagenes en el array de posiciones
        {

            asignadas[0] = 0;
            asignadas[1] = 0;
            asignadas[2] = 0;
            asignadas[3] = 0;
            asignadas[4] = 0;
           


            img[0] = Memorama.Properties.Resources.comodin2;
            img[1] = Memorama.Properties.Resources.dragon_blanco;
            img[2] = Memorama.Properties.Resources.mago_oscuro;
            img[3] = Memorama.Properties.Resources.dragon_ra;
            img[4] = Memorama.Properties.Resources.exodia;
          
                posicion[asignar.Next(8)] = img[0];//asigna primero el comodin en un posicion aleatoria
               
          

  /////////////////////////////////////////////
            /*
             * asigna las cartas de forma aleatoria
             * si la posicion ya esta con la imagen del comodin se la salta
             */
            for (int i = 0; i < 9; i++) {
                if (posicion[i] != img[0] ) {
                    do{
                        elegida = asignar.Next(1, 5);
                }while (asignadas[elegida]==2) ;
                    posicion[i] = img[elegida];
                    asignadas[elegida]++;
                }
            
            }
////////////////////////////////////////////
        }
        public void bloquear_controles() //Desabilita todos los PictureBox
        {
            carta01.Enabled = false;
            carta02.Enabled = false;
            carta03.Enabled = false;
            carta04.Enabled = false;
            carta05.Enabled = false;
            carta06.Enabled = false;
            carta07.Enabled = false;
            carta08.Enabled = false;
            carta09.Enabled = false;

        
        }
        public void encender_controles()//Habilita todo los PicureBox
        {
            carta01.Enabled = true;
            carta02.Enabled = true;
            carta03.Enabled = true;
            carta04.Enabled = true;
            carta05.Enabled = true;
            carta06.Enabled = true;
            carta07.Enabled = true;
            carta08.Enabled = true;
            carta09.Enabled = true;
        
        }

        public void evaluador()//Realiza los calculos de evaluacion para determinar si hay cartar iguales 
        {
            
            if (oportunidades == 0) { bloquear_controles(); MessageBox.Show("Perdiste tus oportunidades", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                this.jugadas = jugadas + 1;
                contador_igual++;
                Njugadas.Text = Convert.ToString(jugadas);
                conta_oportunidades.Text = Convert.ToString(oportunidades);
                if (contador_igual == 3)
                {
                    // habilita nuevamente los Picture box que no eran iguales 
                    seleccionado[3].Enabled = true;
                    seleccionado[4].Enabled = true;
                    ///////////

                    //Coloca la imagen por defecto si no son iguales 
                    seleccionado[3].BackgroundImage = xdefexto;
                    seleccionado[3].BackgroundImageLayout = ImageLayout.Stretch;
                    seleccionado[4].BackgroundImage = xdefexto;
                    seleccionado[4].BackgroundImageLayout = ImageLayout.Stretch;

                    contador_igual = 1;//contador comienza en 1 ya que si llega aqui es por que ya se le a dado otro click
                    ///////////////////
                }
                if (seleccionado[0] != null && seleccionado[1] != null)//Evalua si ya se selecionaron 2 cartas
                {

                    if (select[0] == select[1]) //Evalua si las cartas seleccionadas son iguales 
                    {
                        conta_acertada++;
                        seleccionado[0].Enabled = false;
                        seleccionado[1].Enabled = false;

                        seleccionado[0] = null;
                        seleccionado[1] = null;
                        contador_igual = 0;
                        if (conta_acertada == 4) { bloquear_controles(); MessageBox.Show("!!Felicidades acertaste todas las parejas", "Ganaste", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    }
                    else// si no son iguales pasa esas 2 a otras dos posiciones del array y las dos primeras las limpia
                    {
                        seleccionado[3] = seleccionado[0];
                        seleccionado[4] = seleccionado[1];
                        seleccionado[0] = null;
                        seleccionado[1] = null;
                        oportunidades--;
                        conta_oportunidades.Text = Convert.ToString(oportunidades);
                       
                    }
                }

            }

        }

        public void inicio_tablero()//Establece el estado inicial del los PictureBox
        {


            jugadas = 0;
            seleccionado[0] = null;
            seleccionado[1] = null;

            carta01.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta01.BackgroundImageLayout = ImageLayout.Stretch;
            carta02.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta02.BackgroundImageLayout = ImageLayout.Stretch;
            carta03.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta03.BackgroundImageLayout = ImageLayout.Stretch;
            carta04.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta04.BackgroundImageLayout = ImageLayout.Stretch;
            carta05.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta05.BackgroundImageLayout = ImageLayout.Stretch;
            carta06.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta06.BackgroundImageLayout = ImageLayout.Stretch;
            carta07.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta07.BackgroundImageLayout = ImageLayout.Stretch;
            carta08.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta08.BackgroundImageLayout = ImageLayout.Stretch;
            carta09.BackgroundImage = Memorama.Properties.Resources.imgdefault;
            carta09.BackgroundImageLayout = ImageLayout.Stretch;

            for (int i = 0; i < posicion.Length; i++) {
                posicion[i] = xdefexto;
            }
        }


//////////////////////////////////////////////////////////////////////////////////////////////


        private void Form1_Load(object sender, EventArgs e)
        {
            inicio_tablero();
            revolver_cartas();
          
        }

        private void reset_Click(object sender, EventArgs e)//Reestablece el juego a su estado inicial
        {
            inicio_tablero();
            revolver_cartas();
            encender_controles();
            Njugadas.Text = "0";
            seleccionado[0] = null;
            seleccionado[1] = null;
            contador_igual = 0;
            oportunidades = 3;
            conta_acertada = 0;
            conta_oportunidades.Text = Convert.ToString(oportunidades);
            

        }



        private void carta01_Click(object sender, EventArgs e)
        {
            carta01.Enabled = false;
            carta01.BackgroundImage = posicion[0];
            carta01.BackgroundImageLayout = ImageLayout.Stretch;
           

            if (posicion[0] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta01;
                    select[0] = posicion[0];
                }
                else {
                    seleccionado[1] = carta01;
                    select[1]= posicion[0];
                }
                evaluador();
            }
            
        }

        private void carta02_Click(object sender, EventArgs e)
        {
            carta02.Enabled = false;
            carta02.BackgroundImage = posicion[1];
            carta02.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[1] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta02;
                    select[0]= posicion[1];
                }
                else { seleccionado[1] = carta02;
                select[1] = posicion[1];
                }
                evaluador();
            }
        }

        private void carta03_Click(object sender, EventArgs e)
        {
            carta03.Enabled = false;
            carta03.BackgroundImage = posicion[2];
            carta03.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[2] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta03;
                    select[0] = posicion[2];
                }
                else { 
                    seleccionado[1] = carta03; }
                select[1] = posicion[2];
                evaluador();
            }
        }

        private void carta04_Click(object sender, EventArgs e)
        {
            carta04.Enabled = false;
            carta04.BackgroundImage = posicion[3];
            carta04.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[3] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta04;
                    select[0] = posicion[3];
                }
                else { seleccionado[1] = carta04;
                select[1] = posicion[3];
                }
                evaluador();
            }
        }

        private void carta05_Click(object sender, EventArgs e)
        {
            carta05.Enabled = false;
            carta05.BackgroundImage = posicion[4];
            carta05.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[4] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta05;
                    select[0] = posicion[4];
                }
                else { seleccionado[1] = carta05;
                select[1] = posicion[4];
                }
                evaluador();
            }
        }

        private void carta06_Click(object sender, EventArgs e)
        {
            carta06.Enabled = false;
            carta06.BackgroundImage = posicion[5];
            carta06.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[5] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta06;
                    select[0] = posicion[5];
                }
                else { seleccionado[1] = carta06;
                select[1] = posicion[5];
                }
                evaluador();
            }
        }

        private void carta07_Click(object sender, EventArgs e)
        {
            carta07.Enabled = false;
            carta07.BackgroundImage = posicion[6];
            carta07.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[6] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta07;
                    select[0] = posicion[6];
                }
                else { seleccionado[1] = carta07;
                select[1] = posicion[6];
                }
                evaluador();
            }
        }

        private void carta08_Click(object sender, EventArgs e)
        {
            carta08.Enabled = false;
            carta08.BackgroundImage = posicion[7];
            carta08.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[7] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta08;
                    select[0] = posicion[7];
                }
                else { seleccionado[1] = carta08;
                select[1] = posicion[7];
                }
                evaluador();
            }
        }

        private void carta09_Click(object sender, EventArgs e)
        {
            carta09.Enabled = false;
            carta09.BackgroundImage = posicion[8];
            carta09.BackgroundImageLayout = ImageLayout.Stretch;

            if (posicion[8] == img[0])
            {
                bloquear_controles();
                MessageBox.Show("UPS! El Mago robo tu tiempo" + Environment.NewLine + "Ya valiste madre xD", "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (seleccionado[0] == null)
                {
                    seleccionado[0] = carta09;
                    select[0] = posicion[8];
                }
                else { seleccionado[1] = carta09;
                select[1] = posicion[8];
                }
                evaluador();
            }
        }

        private void Njugadas_Click(object sender, EventArgs e)
        {
            
        }
    }
}
