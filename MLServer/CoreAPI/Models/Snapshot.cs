// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MMLServer.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Snapshot
    {
        /// <summary>
        /// Initializes a new instance of the Snapshot class.
        /// </summary>
        public Snapshot()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Snapshot class.
        /// </summary>
        /// <param name="id">Unique identifier representing the
        /// snapshot.</param>
        /// <param name="name">Name of the snapshot.</param>
        /// <param name="owner">Owner of the snapshot.</param>
        /// <param name="creationTime">Creation time of the snapshot.</param>
        /// <param name="contentSize">Size of the zip file of the
        /// snapshot.</param>
        public Snapshot(string id = default(string), string name = default(string), string owner = default(string), string creationTime = default(string), int? contentSize = default(int?))
        {
            Id = id;
            Name = name;
            Owner = owner;
            CreationTime = creationTime;
            ContentSize = contentSize;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unique identifier representing the snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets owner of the snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets creation time of the snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "creationTime")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets or sets size of the zip file of the snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "contentSize")]
        public int? ContentSize { get; set; }

    }
}
