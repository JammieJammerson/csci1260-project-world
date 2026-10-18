using System;

public abstract class GameEntity : IDescribe
{


    protected abstract string Summary();
    protected abstract string DescribeDetails();

    public virtual string Describe()
    {
        return Summary() + "\n" + DescribeDetails();
    }
}
