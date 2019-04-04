using System;

namespace AttributesExamples
{
    [Flags]
    public enum PreferredContactMethods
    {
        None = 0,
        LandPhone = 1,
        CellPhone = 2,
        Email = 4,
        SnailMail = 8,
        Owl = 16,
        FlooPowder = 32,
        Text = 64,
        Muggle = Email | Text | CellPhone,
        Wizard = Owl | FlooPowder
    }
}
