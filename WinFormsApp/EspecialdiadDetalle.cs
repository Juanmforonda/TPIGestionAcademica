using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionAcademica.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class EspecialidadDetalle : Form
    {
        private EspecialidadDto especialidad;
        private FormMode mode;

        public EspecialidadDto Especialidad
        {
            get { return especialidad; }
            set
            {
                especialidad = value;
                this.SetEspecialidad();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        public EspecialidadDetalle()
        {
            InitializeComponent();
            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateEspecialidad())
            {
                try
                {
                    this.Especialidad.Descripcion = descripcionTextBox.Text;

                    if (this.Mode == FormMode.Update)
                    {
                        await EspecialidadApiClient.UpdateAsync(this.Especialidad);
                    }
                    else
                    {
                        await EspecialidadApiClient.AddAsync(this.Especialidad);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetEspecialidad()
        {
            this.idTextBox.Text = this.Especialidad.ID.ToString();
            this.descripcionTextBox.Text = this.Especialidad.Descripcion;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidateEspecialidad()
        {
            bool isValid = true;

            errorProvider.SetError(descripcionTextBox, string.Empty);

            if (this.descripcionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(descripcionTextBox, "La Descripción es requerida");
            }

            return isValid;
        }
    }
}

