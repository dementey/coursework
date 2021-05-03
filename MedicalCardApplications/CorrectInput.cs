using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalCardApplications
{
    class CorrectInput
    {
        public static void NumberAndLetters(KeyPressEventArgs e)
        {
            try
            {
                if ((Char.IsLetterOrDigit(e.KeyChar)) || (e.KeyChar == 8)) e.Handled = false;
                else throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат ввода! Введите цифры/буквы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        public static void Letters(KeyPressEventArgs e)
        {
            try
            {
                if ((Char.IsLetter(e.KeyChar)) || (e.KeyChar == 8) || (e.KeyChar == 32)) e.Handled = false;
                else throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат ввода! Введите буквы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        public static void Number(KeyPressEventArgs e)
        {
            try
            {
                if ((Char.IsDigit(e.KeyChar)) || (e.KeyChar == 8)) e.Handled = false;
                else throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат ввода! Введите цифры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
    }
}
