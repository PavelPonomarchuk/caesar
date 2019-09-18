using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caesar2
{
    public class Encoder
    {
        private char[] alphabet = new char[]
            { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        public string Clean(string openMessage)
        {
            var builder = new StringBuilder();
            
            foreach (var symbol in openMessage)
            {
                var sym = symbol;
                if (char.IsUpper(sym)) sym = char.ToLower(sym);
                foreach (var c in alphabet)
                    if (sym == c) builder.Append(sym);
            }
            var cleanMessage = builder.ToString();
            return cleanMessage;
        }

        public string Encode(string openMessage)
        {            
            int index = 0;
            var builder = new StringBuilder();
            string cleanMessage = Clean(openMessage);

            foreach (var letter in cleanMessage)
            {
                for (int i = 0; i < 33; i++)
                {                    
                    if (letter == alphabet[i])
                    {
                        index = i;
                        break;
                    }
                }
                if (index <= 29) index = index + 3;
                else if (index > 29) index = index - 30;                                
                builder.Append(alphabet[index]);
            }
            var encodedMessage = builder.ToString();
            return encodedMessage;
        }

        public string Decode(string encodedMessage)
        {
            int index = 0;
            var builder = new StringBuilder();
            
            foreach (var letter in encodedMessage)
            {
                for (int i = 0; i < 33; i++)
                {
                    if (letter == alphabet[i])
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 3) index = index - 3;
                else if (index < 3) index = index + 30;
                builder.Append(alphabet[index]);
            }
            var decodedMessage = builder.ToString();
            return decodedMessage;
        }
    }
}
