public struct PieceMovs
{
    public int first;
    public int second;
    public int third;
    public int forth;
    public int count;
    public int value;



    public PieceMovs(int first, int second, int third, int forth)
    {
        this.first = first;
        this.second = second;
        this.third = third;
        this.forth = forth;
        value = 0;
        count = 4;
        value = (int)GetValue();
    }

    public PieceMovs(int[] all)
    {
        this.first = all[0];
        this.second = all[1];
        this.third = all[2];
        this.forth = all[3];
        value = 0;
        count = 0;
        value = (int)GetValue();
    }

    public bool Add(int newint)
    {
        switch (count)
        {
            case (0):
                first = newint;
                count++;
                break;
            case (1):
                second = newint;
                count++;
                break;
            case (2):
                third = newint;
                count++;
                break;
            case (3):
                forth = newint;
                count++;
                value = (int)GetValue();
                break;
            default:
                return false;
        }
        return true;
    }

    public int Count()
    {
        return count;
    }

    public bool Clear()
    {
        count = 0;
        return true;
    }

    int GetValue()
    {
        int equals = 0;
        if (first == second)
            equals++;
        if (first == third)
            equals++;
        if (first == forth)
            equals++;
        if (second == third)
            equals++;
        if (second == forth)
            equals++;
        if (third == forth)
            equals++;
        return (15 - equals * 2);
    }
}

