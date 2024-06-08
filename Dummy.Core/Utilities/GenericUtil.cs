namespace Dummy.Core.Utilities;

public static class GenericUtil
{
    public static int ToInt32(this object obj)
    {
        try
        {
            if (obj == null)
                return 0;
            return Convert.ToInt32(obj);
        }
        catch
        {
            return 0;
        }
    }

    public static long ToInt64(this object obj)
    {
        try
        {
            if (obj == null)
                return 0;
            return Convert.ToInt64(obj);
        }
        catch
        {
            return 0;
        }
    }

    public static short ToShort(this object obj)
    {
        try
        {
            if (obj == null)
                return 0;
            return (short)Convert.ToInt32(obj);
        }
        catch
        {
            return 0;
        }
    }
}