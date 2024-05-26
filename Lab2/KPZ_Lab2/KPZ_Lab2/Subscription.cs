using System.Collections.Generic;

public abstract class Subscription
{
    public abstract string Name { get; }
    public abstract decimal MonthlyFee { get; }
    public abstract int MinimumPeriod { get; }
    public abstract List<string> Channels { get; }
    public abstract List<string> Features { get; }
}
