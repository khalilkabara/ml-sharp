namespace ml_sharp.Enums.Genetics
{
    /// <summary>
    /// Defines how mutation affects offspring in genetic breeding.
    /// A positive value ensures that offspring yield better TraitValue than parents.
    /// A Negative value ensures that offspring yield lesser TraitValue than parents.
    /// When Random is used, there's no telling if TraitValue will improve or decline. This is set by default.
    /// It makes breeding seem more natural.
    /// </summary>
    public enum EMutationEffect
    {
        Positive,
        Negative,
        Random
    }
}