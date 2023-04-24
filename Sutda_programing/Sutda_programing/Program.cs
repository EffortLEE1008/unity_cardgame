// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/////////index num[0    1    2    3    4    5    6    7    8    9]
///////////////////1    2    3    4    5    6    7    8    9   10
string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};


Dictionary<string, int> jokbo = new Dictionary<string, int>()
{   //dictionary에 10땡 까지 추가하기
    { "aA", 200 },
};

//List 사용해서 player0 만들고, 카드 2장 넣어보기.

List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();

player0.Add(deck[0]);
player0.Add(deck[10]);

computer1.Add(deck[3]);
computer1.Add(deck[9]);


player0.Sort();

string player0_value = player0[0] + player0[1];
Console.WriteLine(player0_value); //aA


Console.WriteLine(jokbo[player0_value]);