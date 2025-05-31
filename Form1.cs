using MaterialSkin;
using System.IO; // ← asegúrate de tener esta línea
using System.Drawing;
using MaterialSkin.Controls;
using IA_AlertaDesaparecidos_MaterialSkin;
using System.Windows.Forms;
using System;
using alertasUrgentes.clases;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace alertasUrgentes
{
    public partial class Form1 : MaterialForm // Change inheritance to MaterialForm
    {
        private MaterialTextBox txtAlerta;
        private MaterialButton btnAnalizar;




        // Cambia aquí tu string de conexión a SQL Server
        private string connectionString = @"Server=DESKTOP-MC98NOL\SQLEXPRESS;Database=alertasAlbaKenethdb;Trusted_Connection=True;";
        private DatabaseHelper dbHelper;
        EmailHelper emailHelper = new EmailHelper();
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMiAlerta;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblResultadoTop5;
        private System.Windows.Forms.PictureBox pictureBoxIcono;
        private ListBox listBoxTopAlertas;
        private MaterialMultiLineTextBox txtResultadoTop5; // Add this declaration

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(connectionString);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtAlerta = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAnalizar = new MaterialSkin.Controls.MaterialButton();
            this.txtResultado = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.txtResultadoTop5 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMiAlerta = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pictureBoxIcono = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlerta
            // 
            this.txtAlerta.AnimateReadOnly = false;
            this.txtAlerta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlerta.Depth = 0;
            this.txtAlerta.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAlerta.LeadingIcon = null;
            this.txtAlerta.Location = new System.Drawing.Point(20, 216);
            this.txtAlerta.MaxLength = 500;
            this.txtAlerta.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAlerta.Multiline = false;
            this.txtAlerta.Name = "txtAlerta";
            this.txtAlerta.Size = new System.Drawing.Size(480, 50);
            this.txtAlerta.TabIndex = 0;
            this.txtAlerta.Text = "";
            this.txtAlerta.TrailingIcon = null;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnalizar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAnalizar.Depth = 0;
            this.btnAnalizar.HighEmphasis = true;
            this.btnAnalizar.Icon = null;
            this.btnAnalizar.Location = new System.Drawing.Point(189, 275);
            this.btnAnalizar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAnalizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAnalizar.Size = new System.Drawing.Size(130, 36);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Enviar Alerta";
            this.btnAnalizar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAnalizar.UseAccentColor = false;
            btnAnalizar.Click += BtnAnalizar_Click;
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultado.Depth = 0;
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtResultado.Location = new System.Drawing.Point(20, 389);
            this.txtResultado.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(480, 200);
            this.txtResultado.TabIndex = 2;
            this.txtResultado.Text = "";
            // 
            // txtResultadoTop5
            // 
            this.txtResultadoTop5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtResultadoTop5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultadoTop5.Depth = 0;
            this.txtResultadoTop5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtResultadoTop5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtResultadoTop5.Location = new System.Drawing.Point(625, 217);
            this.txtResultadoTop5.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtResultadoTop5.Name = "txtResultadoTop5";
            this.txtResultadoTop5.Size = new System.Drawing.Size(400, 200);
            this.txtResultadoTop5.TabIndex = 4;
            this.txtResultadoTop5.Text = "";
            this.txtResultadoTop5.TextChanged += new System.EventHandler(this.txtResultadoTop5_TextChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 70);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Sistema de Alertas – Nueva Alerta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiAlerta
            // 
            this.lblMiAlerta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMiAlerta.Location = new System.Drawing.Point(16, 181);
            this.lblMiAlerta.Name = "lblMiAlerta";
            this.lblMiAlerta.Size = new System.Drawing.Size(100, 20);
            this.lblMiAlerta.TabIndex = 2;
            this.lblMiAlerta.Text = "Mi Alerta";
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResultado.Location = new System.Drawing.Point(21, 354);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(200, 20);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Resultado del Análisis:";
            // 
            // pictureBoxIcono
            // 
            this.pictureBoxIcono.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcono.Image")));
            this.pictureBoxIcono.Location = new System.Drawing.Point(243, 103);
            this.pictureBoxIcono.Name = "pictureBoxIcono";
            this.pictureBoxIcono.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcono.TabIndex = 0;
            this.pictureBoxIcono.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(621, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Top 5 Alertas:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1136, 629);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxIcono);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblMiAlerta);
            this.Controls.Add(this.txtAlerta);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.txtResultadoTop5);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.txtResultadoTop5_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private async void BtnAnalizar_Click(object sender, EventArgs e)
        {
            string alertaTexto = txtAlerta.Text;
            // ✅ Validar que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(alertaTexto))
            {
                MessageBox.Show("Por favor escribe una alerta antes de enviarla.");
                return;
            }

            // Aquí se instancia la clase GroqClient
            string apiKey = "API_KEY";
            var cliente = new GroqClient(apiKey); // 

            try
            {
                // Aquí se llama el método AnalizarAlerta
                string resultado = await cliente.AnalizarAlerta(alertaTexto);
                txtResultado.Text = resultado;


                
                     emailHelper.EnviarEmail(
                      "lpinedac7@miumg.edu.gt",
                      "¡Alerta de reporte urgente!",
                      $"Se ha recibido un nuevo reporte con gravedad alta. Revisar el sistema.\n\nResultado del análisis:\n{resultado}"
                  );
                // ✅ Mostrar mensaje de confirmación
                MessageBox.Show("✅ El correo fue enviado correctamente.", "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Guardar en SQL Server
                dbHelper.GuardarAnalisis(alertaTexto, resultado);
                CargarTopAlertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con Groq: " + ex.Message);
            }
        }

        public class Alerta
        {
            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public string Prompt { get; set; }
            public string Respuesta { get; set; }
        }

        void CargarTopAlertas()
        {
          
            string query = @"
        SELECT TOP 5 Prompt, COUNT(*) AS Frecuencia
        FROM Alerta
        GROUP BY Prompt
        ORDER BY Frecuencia DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                StringBuilder sb = new StringBuilder();
                int i = 1;
                while (reader.Read())
                {
                    string prompt = reader["Prompt"].ToString();
                    int frecuencia = (int)reader["Frecuencia"];
                    sb.AppendLine($"{i}. {prompt} (Veces: {frecuencia})");
                    i++;
                }

                txtResultadoTop5.Text = sb.ToString();


            }
        }

        private void txtResultadoTop5_TextChanged(object sender, EventArgs e)
        {
            CargarTopAlertas(); // Ejecuta el método al iniciar el formulario
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
