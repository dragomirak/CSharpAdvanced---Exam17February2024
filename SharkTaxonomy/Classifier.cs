using System.Linq;
using System.Text;

namespace SharkTaxonomy;

public class Classifier
{
    public Classifier(int capacity)
    {
        Capacity = capacity;
        Species = new List<Shark>();
    }

    public int Capacity { get; set; }
    public List<Shark> Species { get; set; }
    public int GetCount => Species.Count;
    public void AddShark(Shark shark)
    {
        if (Capacity > GetCount && !Species.Contains(shark))
        {
            Species.Add(shark);
        }
    }
    public bool RemoveShark(string kind)
    {
        Shark sharkToRemove = Species.FirstOrDefault(s => s.Kind == kind);
        if (sharkToRemove != null)
        {
            return Species.Remove(sharkToRemove);
        }
        return false;
    }
    public string GetLargestShark()
    {
        Shark largestShark = Species.OrderByDescending(s => s.Length).First();
        return largestShark.ToString();
    }
    public double GetAverageLength()
    {
        double totalLength = 0;
        foreach (Shark shark in Species)
        {
            totalLength += shark.Length;
        }
        double averageLength = totalLength / GetCount;
        return averageLength;
    }
    public string Report()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{GetCount} sharks classified:");
        foreach (Shark shark in Species)
        {
            sb.AppendLine(shark.ToString());
        }
        return sb.ToString().Trim();
    }
}
