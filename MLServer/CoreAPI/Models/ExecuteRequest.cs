// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MMLServer.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ExecuteRequest
    {
        /// <summary>
        /// Initializes a new instance of the ExecuteRequest class.
        /// </summary>
        public ExecuteRequest()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ExecuteRequest class.
        /// </summary>
        /// <param name="code">code to execute. **&lt;font color =
        /// 'red'&gt;Required&lt;/font&gt;**</param>
        /// <param name="inputParameters">Input parameters for the execution.
        /// **Optional**</param>
        /// <param name="outputParameters">Output parameters for the execution.
        /// **Optional**</param>
        public ExecuteRequest(string code = default(string), IList<WorkspaceObject> inputParameters = default(IList<WorkspaceObject>), IList<string> outputParameters = default(IList<string>))
        {
            Code = code;
            InputParameters = inputParameters;
            OutputParameters = outputParameters;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets code to execute. **&amp;lt;font color =
        /// 'red'&amp;gt;Required&amp;lt;/font&amp;gt;**
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets input parameters for the execution. **Optional**
        /// </summary>
        [JsonProperty(PropertyName = "inputParameters")]
        public IList<WorkspaceObject> InputParameters { get; set; }

        /// <summary>
        /// Gets or sets output parameters for the execution. **Optional**
        /// </summary>
        [JsonProperty(PropertyName = "outputParameters")]
        public IList<string> OutputParameters { get; set; }

    }
}
