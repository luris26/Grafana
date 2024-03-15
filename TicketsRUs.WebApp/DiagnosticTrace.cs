using System.Diagnostics;

public class DiagnosticsTrace
{
    public static readonly string SourceName = "luris_tracexd_1";
    public static readonly string SourceName2 = "luris_tracexd_2";
    public static readonly ActivitySource ActionSource = new(SourceName);
    public static readonly ActivitySource ActionSource2  = new(SourceName2);
}