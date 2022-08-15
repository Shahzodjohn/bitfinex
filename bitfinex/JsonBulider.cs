using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitfinex
{
    class JsonBulider
    {
        private List<string> _queue = new();

        public JsonBulider Pair(string key, string value)
        {
            _queue.Add($"\"{key}\": \"{value}\"");
            return this;
        }

        public string Build()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("{");
            for (int i = 0; i < _queue.Count; ++i)
            {
                var pair = _queue[i];

                stringBuilder.AppendLine(pair + (i + 1 == _queue.Count ? "" : ","));
            }
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}
