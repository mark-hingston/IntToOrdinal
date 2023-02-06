namespace IntToOrdinal
{
    public interface ILanguage
    {
        string GetOrdinal(uint number);

        string GetFullOrdinal(uint number, bool hyphenate = false);
    }
}
