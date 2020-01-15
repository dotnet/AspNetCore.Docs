using Microsoft.AspNetCore.Mvc;
using System;

namespace RoutingSample
{
    #region snippet
    public interface ICoolMetadata
    {
        bool IsCool { get; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CoolMetadataAttribute : Attribute, ICoolMetadata
    {
        public bool IsCool => true;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SuppressCoolMetadataAttribute : Attribute, ICoolMetadata
    {
        public bool IsCool => false;
    }

    [CoolMetadata]
    public class MyController : Controller
    {
        [SuppressCoolMetadata]
        public void Uncool() { }
    }
    #endregion
}
