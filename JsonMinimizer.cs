using System.Reflection.PortableExecutable;
using System.Text;

namespace JsonMinimizer
{
    public class JsonMinimizer
    {
        private bool StringProcess = false;
        private StringReader? stringReader;
        private StringBuilder? stringBuilder;
        public JsonMinimizer(string? jsonData)
        {
            if (jsonData != null)
            {
                stringReader = new StringReader(jsonData);
                stringBuilder = new StringBuilder();
            }
        }

        public string getString()
        {
            if (stringBuilder != null)
            {
                return stringBuilder.ToString();
            }
            return "";
        }

        public void Minimize()
        {
            if (stringReader != null)
            {
                int ch;
                while (true)
                {
                    ch = stringReader.Read();
                    if (ch == -1)
                    {
                        break;
                    }
                    if ((char)ch == '"')
                    {
                        StringProcess = !StringProcess;
                    }
                    if (StringProcess == true)
                    {
                        if (stringBuilder != null)
                        {
                            stringBuilder.Append((char) ch);
                        }
                    } 
                    if (StringProcess == false)
                    {
                        if (ch == ' ')
                        {
                            continue;
                        }
                        if (stringBuilder != null)
                        {
                            stringBuilder.Append((char) ch);
                        }
                    }
                }
            }
        }
    }
}