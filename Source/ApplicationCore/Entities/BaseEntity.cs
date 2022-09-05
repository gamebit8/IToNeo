using System;

namespace IToNeo.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get;}
        public byte[] Timestamp { get; set; }
    }
}
