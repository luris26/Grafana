using System.Diagnostics.Metrics;

public static class Meters{
    public static Meter myhomeworkmeter = new Meter("LurisHomework.DemoTicket", "2.0.7");
    public static Counter<int> quantity = myhomeworkmeter.CreateCounter<int>("counter_ticket_Luris");
}