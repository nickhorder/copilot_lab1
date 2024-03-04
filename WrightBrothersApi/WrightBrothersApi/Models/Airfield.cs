// The Wright Brothers, Orville and Wilbur Wright, conducted their aviation experiments at a few key locations.
// These locations were central to the development and testing of the Wright Brothers' aircraft designs.
// Each site played a crucial role in the evolution of their flying machines, from the early gliders to the first practical powered airplanes. 
//
// The 'Airfield' class represents a location where the Wright Brothers tested their aircraft designs.
public class Airfield
{
    // Properties
    public string Name { get; set; }
    public string Location { get; set; }
    public string DatesOfUse { get; set; }
    public string Significance { get; set; }

    // Constructor
    public Airfield(string name, string location, string datesOfUse, string significance)
    {
        Name = name;
        Location = location;
        DatesOfUse = datesOfUse;
        Significance = significance;
    }
}