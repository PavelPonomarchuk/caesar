using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace caesar2
{
    class MyForm : Form
    {
        
        public MyForm()
        {
            var labelInput = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = "Введите исходный текст:"
            };
            var boxInput = new TextBox
            {
                Location = new Point(0, labelInput.Bottom),
                Size = new Size(ClientSize.Width, 100)
            };
            var labelOutput = new Label
            {
                Location = new Point(0, boxInput.Bottom),
                Size = labelInput.Size,
                Text = "Результат:"
            };
            var boxOutput = new TextBox
            {
                Location = new Point(0, labelOutput.Bottom),
                Size = boxInput.Size
            };
            var buttonEncode = new Button
            {
                Location = new Point(0, boxOutput.Bottom),
                Size = labelOutput.Size,
                Text = "Зашифровать"
            };
            var buttonDecode = new Button
            {
                Location = new Point(0, buttonEncode.Bottom),
                Size = labelOutput.Size,
                Text = "Расшифровать"
            };
            Controls.Add(labelInput);
            Controls.Add(boxInput);
            Controls.Add(labelOutput);
            Controls.Add(boxOutput);
            Controls.Add(buttonEncode);
            Controls.Add(buttonDecode);

            buttonEncode.Click += (sender, args) =>
            {
                var encoder = new Encoder();
                boxOutput.Text = encoder.Encode(boxInput.Text);
            };
            buttonDecode.Click += (sender, args) =>
            {
                var encoder = new Encoder();
                boxOutput.Text = encoder.Decode(boxInput.Text);
            };
        }        
    }
}
