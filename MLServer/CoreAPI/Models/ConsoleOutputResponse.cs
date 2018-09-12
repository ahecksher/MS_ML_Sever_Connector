// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MMLServer.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ConsoleOutputResponse
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleOutputResponse class.
        /// </summary>
        public ConsoleOutputResponse()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ConsoleOutputResponse class.
        /// </summary>
        /// <param name="consoleOutput">Console output of the current or last
        /// execution</param>
        public ConsoleOutputResponse(string consoleOutput = default(string))
        {
            ConsoleOutput = consoleOutput;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets console output of the current or last execution
        /// </summary>
        [JsonProperty(PropertyName = "consoleOutput")]
        public string ConsoleOutput { get; set; }

    }
}
