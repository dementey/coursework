using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedicalCardApplications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.vaccineTableAdapter.Fill(this.medicalCardDataSet.Vaccine);
            this.diseaseTableAdapter.Fill(this.medicalCardDataSet.Disease);
            this.anthropologicalTableAdapter.Fill(this.medicalCardDataSet.Anthropological);
            this.medicalCardTableAdapter.Fill(this.medicalCardDataSet.MedicalCard);
            this.companyEmployeeTableAdapter.Fill(this.medicalCardDataSet.CompanyEmployee);
            this.divisionTableAdapter.Fill(this.medicalCardDataSet.Division);
            this.departmentEmployeeTableAdapter.Fill(this.medicalCardDataSet.DepartmentEmployee);
            departmentEmployeeBindingSource.DataSource = this.medicalCardDataSet.DepartmentEmployee;
            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView3.Columns[0].Visible = false;
            dataGridView5.Columns[0].Visible = false;
            dataGridView6.Columns[0].Visible = false;
            dataGridView7.Columns[0].Visible = false;
        }

        #region ADD\DELETE\SAVE
        private void button1_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                medicalCardDataSet.DepartmentEmployee.AddDepartmentEmployeeRow(medicalCardDataSet.DepartmentEmployee.NewDepartmentEmployeeRow());
                departmentEmployeeBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentEmployeeBindingSource.ResetBindings(false);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel2.Enabled = true;
                textBox13.Focus();
                medicalCardDataSet.Division.AddDivisionRow(this.medicalCardDataSet.Division.NewDivisionRow());
                divisionBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                divisionBindingSource.ResetBindings(false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                departmentEmployeeBindingSource.EndEdit();
                departmentEmployeeTableAdapter.Update(medicalCardDataSet.DepartmentEmployee);
                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentEmployeeBindingSource.ResetBindings(false);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                divisionBindingSource.EndEdit();
                divisionTableAdapter.Update(medicalCardDataSet.Division);
                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                divisionBindingSource.ResetBindings(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ред
            panel1.Enabled = true;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //отмена
            panel1.Enabled = false;
            departmentEmployeeBindingSource.ResetBindings(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                departmentEmployeeBindingSource.RemoveCurrent();
            departmentEmployeeBindingSource.EndEdit();
            departmentEmployeeTableAdapter.Update(medicalCardDataSet.DepartmentEmployee);
            UpdateToCascadeDelete();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //ред
            panel2.Enabled = true;
            textBox13.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            divisionBindingSource.ResetBindings(false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                divisionBindingSource.RemoveCurrent();
            divisionBindingSource.EndEdit();
            divisionTableAdapter.Update(medicalCardDataSet.Division);
            UpdateToCascadeDelete();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel3.Enabled = true;
                textBox18.Focus();
                medicalCardDataSet.CompanyEmployee.AddCompanyEmployeeRow(medicalCardDataSet.CompanyEmployee.NewCompanyEmployeeRow());
                companyEmployeeBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyEmployeeBindingSource.ResetBindings(false);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //ред
            panel3.Enabled = true;
            textBox18.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                companyEmployeeBindingSource.EndEdit();
                companyEmployeeTableAdapter.Update(medicalCardDataSet.CompanyEmployee);
                panel3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyEmployeeBindingSource.ResetBindings(false);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //отмена
            panel3.Enabled = false;
            companyEmployeeBindingSource.ResetBindings(false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                companyEmployeeBindingSource.RemoveCurrent();
            companyEmployeeBindingSource.EndEdit();
            companyEmployeeTableAdapter.Update(medicalCardDataSet.CompanyEmployee);
            UpdateToCascadeDelete();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel4.Enabled = true;
                medicalCardDataSet.MedicalCard.AddMedicalCardRow(medicalCardDataSet.MedicalCard.NewMedicalCardRow());
                medicalCardBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                medicalCardBindingSource.ResetBindings(false);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //ред
            panel4.Enabled = true;
            comboBox3.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                medicalCardBindingSource.EndEdit();
                medicalCardTableAdapter.Update(medicalCardDataSet.MedicalCard);
                panel4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                medicalCardBindingSource.ResetBindings(false);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //отмена
            panel4.Enabled = false;
            medicalCardBindingSource.ResetBindings(false);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                medicalCardBindingSource.RemoveCurrent();
            medicalCardBindingSource.EndEdit();
            medicalCardTableAdapter.Update(medicalCardDataSet.MedicalCard);
            UpdateToCascadeDelete();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel5.Enabled = true;
                textBox33.Focus();
                medicalCardDataSet.Anthropological.AddAnthropologicalRow(medicalCardDataSet.Anthropological.NewAnthropologicalRow());
                anthropologicalBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                anthropologicalBindingSource.ResetBindings(false);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //ред
            panel5.Enabled = true;
            textBox33.Focus();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                anthropologicalBindingSource.EndEdit();
                anthropologicalTableAdapter.Update(medicalCardDataSet.Anthropological);
                panel5.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                anthropologicalBindingSource.ResetBindings(false);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //отмена
            panel5.Enabled = false;
            anthropologicalBindingSource.ResetBindings(false);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                anthropologicalBindingSource.RemoveCurrent();
            anthropologicalBindingSource.EndEdit();
            anthropologicalTableAdapter.Update(medicalCardDataSet.Anthropological);
            UpdateToCascadeDelete();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel6.Enabled = true;
                textBox34.Focus();
                medicalCardDataSet.Disease.AddDiseaseRow(medicalCardDataSet.Disease.NewDiseaseRow());
                medicalCardBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diseaseBindingSource.ResetBindings(false);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //ред
            panel6.Enabled = true;
            textBox34.Focus();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                diseaseBindingSource.EndEdit();
                diseaseTableAdapter.Update(medicalCardDataSet.Disease);

                panel6.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diseaseBindingSource.ResetBindings(false);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //отмена
            panel6.Enabled = false;
            diseaseBindingSource.ResetBindings(false);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                diseaseBindingSource.RemoveCurrent();
            diseaseBindingSource.EndEdit();
            diseaseTableAdapter.Update(medicalCardDataSet.Disease);
            UpdateToCascadeDelete();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //доб
            try
            {
                panel7.Enabled = true;
                dateTimePicker10.Focus();
                medicalCardDataSet.Vaccine.AddVaccineRow(medicalCardDataSet.Vaccine.NewVaccineRow());
                vaccineBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vaccineBindingSource.ResetBindings(false);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //ред
            panel7.Enabled = true;
            dateTimePicker10.Focus();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //сохр
            try
            {
                vaccineBindingSource.EndEdit();
                vaccineTableAdapter.Update(this.medicalCardDataSet.Vaccine);
                panel7.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vaccineBindingSource.ResetBindings(false);
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //отмена
            panel7.Enabled = false;
            vaccineBindingSource.ResetBindings(false);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //удал
            if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                vaccineBindingSource.RemoveCurrent();
            vaccineBindingSource.EndEdit();
            vaccineTableAdapter.Update(this.medicalCardDataSet.Vaccine);
            UpdateToCascadeDelete();
        }
        #endregion

        public void UpdateToCascadeDelete()
        {
            medicalCardDataSet.DepartmentEmployee.AcceptChanges();
            departmentEmployeeTableAdapter.Fill(medicalCardDataSet.DepartmentEmployee);

            medicalCardDataSet.Division.AcceptChanges();
            divisionTableAdapter.Fill(medicalCardDataSet.Division);

            medicalCardDataSet.CompanyEmployee.AcceptChanges();
            companyEmployeeTableAdapter.Fill(medicalCardDataSet.CompanyEmployee);

            medicalCardDataSet.MedicalCard.AcceptChanges();
            medicalCardTableAdapter.Fill(medicalCardDataSet.MedicalCard);

            medicalCardDataSet.Anthropological.AcceptChanges();
            anthropologicalTableAdapter.Fill(medicalCardDataSet.Anthropological);

            medicalCardDataSet.Disease.AcceptChanges();
            diseaseTableAdapter.Fill(medicalCardDataSet.Disease);

            medicalCardDataSet.Vaccine.AcceptChanges();
            vaccineTableAdapter.Fill(medicalCardDataSet.Vaccine);
        }

        #region SEARCH
        private void button42_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox8.Text))
                        {
                            //dataGridView1.Rows[i].Selected = true;
                            //dataGridView1.Columns[j].Selected = true;
                            dataGridView1.Rows[i].Cells[j].Selected = true;
                            break;
                        }
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox9.Text))
                        {
                            dataGridView2.Rows[i].Cells[j].Selected = true;
                            break;
                        }

            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox10.Text))
                        {
                            dataGridView3.Rows[i].Cells[j].Selected = true;
                            break;
                        }

            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                dataGridView5.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().Contains(textBox24.Text))
                        {
                            dataGridView5.Rows[i].Cells[j].Selected = true;
                            break;
                        }

            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView6.RowCount; i++)
            {
                dataGridView6.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView6.ColumnCount; j++)
                    if (dataGridView6.Rows[i].Cells[j].Value != null)
                        if (dataGridView6.Rows[i].Cells[j].Value.ToString().Contains(textBox25.Text))
                        {
                            dataGridView6.Rows[i].Cells[j].Selected = true;
                            break;
                        }
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                dataGridView7.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView7.ColumnCount; j++)
                    if (dataGridView7.Rows[i].Cells[j].Value != null)
                        if (dataGridView7.Rows[i].Cells[j].Value.ToString().Contains(textBox27.Text))
                        {
                            dataGridView7.Rows[i].Cells[j].Selected = true;
                            break;
                        }
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region CORRECTDATA
        private void dateTimePicker8_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker9.MinDate = dateTimePicker8.Value;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.Letters(e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.Letters(e);
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.Number(e);
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.Number(e);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.Letters(e);
        }
        #endregion

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView9.DataSource = null;
                dataGridView9.DataSource = anthropologicalBindingSource;
                dataGridView9.CurrentCell = null;
                dataGridView9.Columns[0].Visible = false;
                dataGridView9.Columns[4].Visible = false;
                for (int j = 0; j < dataGridView9.Rows.Count - 1; j++)
                {

                    var fc = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].Cells[1].Value;
                    if ((!dataGridView9.Rows[j].Cells[4].Value.Equals(fc)))
                    {
                        dataGridView9.Rows[j].Visible = false;
                    }
                }
            }

            if (radioButton2.Checked)
            {
                dataGridView9.DataSource = null;
                dataGridView9.DataSource = diseaseBindingSource;
                dataGridView9.CurrentCell = null;
                dataGridView9.Columns[0].Visible = false;
                dataGridView9.Columns[4].Visible = false;
                for (int j = 0; j < dataGridView9.Rows.Count - 1; j++)
                {

                    var fc = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].Cells[1].Value;
                    if ((!dataGridView9.Rows[j].Cells[4].Value.Equals(fc)))
                    {
                        dataGridView9.Rows[j].Visible = false;
                    }
                }
            }

            if (radioButton3.Checked)
            {
                dataGridView9.DataSource = null;
                dataGridView9.DataSource = vaccineBindingSource;
                dataGridView9.CurrentCell = null;
                dataGridView9.Columns[0].Visible = false;
                dataGridView9.Columns[3].Visible = false;
                for (int j = 0; j < dataGridView9.Rows.Count - 1; j++)
                {

                    var fc = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].Cells[1].Value;
                    if ((!dataGridView9.Rows[j].Cells[3].Value.Equals(fc)))
                    {
                        dataGridView9.Rows[j].Visible = false;
                    }
                }
            }
        }

        #region ACCESS
        public void Adm()
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
        }

        public void Sot()
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
            tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
            button16.Visible = false;
            button15.Visible = false;
            button14.Visible = false;
            button13.Visible = false;
            button12.Visible = false;
        }
        public bool Auth(string login, string pas)
        {
            this.departmentEmployeeTableAdapter.Fill(this.medicalCardDataSet.DepartmentEmployee);
            if (this.medicalCardDataSet.DepartmentEmployee.Where(x => x.Login == login && x.Password == pas).Count() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}