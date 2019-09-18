using System;
using System.Collections.Generic;

// possible classes
// die X
// deck X
// card X
// player X
// marker X
// game or board

public class Die
{
  // sides value color
  public int val;
  private int sides;
  public int color;

  public Die(int sides, int color)
  {
    this.sides = sides;
    this.color = color;
    this.val = 1;
  }
  public Die(int sides)
  {
    this.sides = sides;
    this.val = 1;
  }
  public Die()
  {
    this.sides = 6;
    this.val = 1;
  }



  // modify the existing class
  public void Roll(Random rand)
  {
    this.val = rand.Next(1, this.sides + 1);
  }
}

public class Card
{

  public int suit;
  public int val;
  private Dictionary<int, string> suit_Map = new Dictionary<int, string>
  {
    {0, "\u2663"},
    {1, "\u2660"},
    {2, "\u2265"},
    {3, "\u2666"}
  };
  private Dictionary<int, string> val_Map = new Dictionary<int, string>
  {
    {1, "Ac"},
    {10, "10"},
    {11, "Ja"},
    {12, "Qu"},
    {13, "Ki"}
  };

  public Card(int val, int suit)
  {
    this.val = val;
    this.suit = suit;
  }

  public string Display()
  {
    if (this.val == 0)
    {
      return "Jkr";
    }

    if (this.valMap.ContainsKey(this.val))
    {
      return this.suit_Map[this.suit] + this.val_Map[this.val];
    }

    return this.suit_Map[this.suit] + "0" + this.val;
  }
}

public class Deck
{
    public List<Card> cards;

    public Deck(int[] values, int[] suits, int numJokers)
    {
        foreach(var suit in suits)
        {
            foreach(var val in values)
            {
                var newCard = new Card(val, suit);
            }
        }
        for (int jkr = 0; jkr < numJokers; jkr++)
        {
          this.cards.Add(newCard); 
        }
    }

    public void Shuffle(Random rand)
    {
        for( int index = this.cards.Count - 1; index > 0; index--)
        {
            int position = rand.Next(index + 1);
            Card temp = this.cards[index];
            this.cards[index] = this.cards[position];
            this.cards[position] = temp;
        }
    }
}
  
public class Marker
{
    public int position;
    public string name;
    
    public Marker(string name)
    {
        this.position = -1;
        this.name = name;
    }

    public virtual void Move(int spaces)
    {
        this.position += spaces;
    }
}
  
public class FLMarker : Marker
{
    public bool stopped;
    public FLMarker(string name) : base(name)
    {
        this.stopped = false;
    }

    // parent has class but use this one instead of parents
    public void Move(int spaces, int stopValue)
    {
        // pre-processing
        this.Move(spaces);
        // post-processing
    }
}
  
public class Player
{
    public Marker[] markers;
    public string name;
  
    public Player(string name, string[] markerNames)
    {
        this.markers = new Marker[markerNames.Length];
        this.name = name;
        for (int markerName = 0; markerName < markerNames.Length; markerName++)
        {
            this.markers[markerName] = new Marker(markerNames[markerName]);
        }
    }
}

  public string HasMarkersAt(int position)
  {
    string master = "";
    foreach (var marker in this.markers)
    {
      if (marker.position == position)
      {
        master += marker.name;
      }
      else
      {
        master += " ";
      }
    }
    return master;
  }
}

public class FinishLine
{
    private readonly int[] SUITS = new int[] { 0, 1, 2, 3 };
    private readonly int[] VALUES = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    private const int NUM_JOKERS = 2;
    private readonly string[] MARKER_NAMES = new String[] {"A", "B", "C"};

    public Deck deck;
    public Die redDie;
    public Die blackDie;
    public Player player1;
    public int players;
    public Random rand;
  
   public FinishLine(int players, string player1Name)
  {
    this.players = players;
    this.player1 = new Player(player1Name, this.MARKER_NAMES);
    this.rand = new Random();
    this.deck = new Deck(this.VALUES, this.SUITS, NUM_JOKERS);
    this.redDie = new Die(6, 0xFF0000);
    this.blackDie = new Die(6, 0x000000);
    this.deck.Shuffle(rand);
    this.redDie.Roll(rand);
    this.blackDie.Roll(rand);
  }
}

public class Program
{
  public static void Main()
  {
    Die redDie = new Die(6, 0xFF0000);
    var blackDie = new Die();
    var rand = new Random();

    Card aCard = new Card(0, -1);
    Console.WriteLine("The card is {0}", aCard.Display());

    // Console.WriteLine("redDie: " + redDie.val);
    // Console.WriteLine("blackDie: {0} {0}", blackDie.val);
    // Console.WriteLine("bigDie: " + bigDie.val);

    // redDie.Roll(rand);
    // blackDie.Roll(rand);
    // bigDie.Roll(rand);


    // Console.WriteLine("After the roll");
    // Console.WriteLine("redDie: " + redDie.val);
    // Console.WriteLine("blackDie: {0} {0}", blackDie.val);
    // Console.WriteLine("bigDie: " + bigDie.val);

  }
}
