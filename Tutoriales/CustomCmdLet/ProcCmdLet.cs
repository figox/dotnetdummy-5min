using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace CustomCmdLet
{
    [Cmdlet(VerbsCommon.Get, "Proc")]
    public class ProcCmdLet : Cmdlet
    {
        private int _slice;

        [Parameter(Mandatory = false)]
        public int slice
        {
            get { return _slice; }
            set { _slice = value; }
        }

        protected override void ProcessRecord()
        {
            var procs = Process.GetProcesses();

            if (_slice > 0)
            {
                procs = procs.Take(_slice).ToArray();
            }

            WriteObject(procs, true);
        }
    }
}
