
/////////index num[0    1    2    3    4    5    6    7    8    9]
///////////////////1    2    3    4    5    6    7    8    9   10
using System.ComponentModel.DataAnnotations;

string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};


Dictionary<string, int> jokbo = new Dictionary<string, int>()
{  
    {"aA", 200 }, {"bB", 220}, {"cC", 240}, {"dD", 260},
    {"eE", 280}, {"fF", 300}, {"gG", 320}, {"hH", 340 },
    {"iI", 360}, {"jJ",380}, //땡들

    {"ab", 80 }, {"aB", 80}, {"Ab", 80}, {"AB", 80}, //알리
    {"ad", 70 }, {"aD", 70}, {"Ad", 70}, {"AD", 70}, //독사
    {"ai", 60}, {"aI", 60}, {"Ai", 60}, {"AI", 60}, // 구삥
    {"aj", 50}, {"aJ", 50}, {"Aj", 50}, {"AJ", 50}, //장삥
    {"di", 40}, {"dI", 40}, {"Di", 40}, {"DI", 40}, //장사
    {"df", 30}, {"dF", 30}, {"Df", 30}, {"DF", 30}, //세륙 

    {"AC", 1300}, {"AH", 1300}, {"CH", 3800} //광땡

};

Dictionary<string, int> non_jokbo = new Dictionary<string, int>()
{
    {"a" , 1 }, {"A",1}, {"b",2}, {"B",2}, {"c", 3}, {"C", 3}, {"d", 4}, {"D", 4}, {"e", 5}, {"E", 5},
    {"f", 6}, {"F", 6}, {"g", 7}, {"G", 7}, {"h", 8}, {"H", 8}, {"i", 9}, {"I", 9}, {"j", 10}, {"J", 10}
};

//List 사용해서 player0 만들고, 카드 2장 넣어보기.


List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();

player0.Add(deck[9]);
player0.Add(deck[4]);                   //카드를 두장 뽑는다.
                                             //ej

computer1.Add(deck[3]);
computer1.Add(deck[8]);


player0.Sort();


string concat_player0 = player0[0] + player0[1];
string concat_computer1 = computer1[0] + computer1[1];
//computer2
//computer3
//computer4

int player0_value;



if (jokbo.ContainsKey(concat_player0))            //족보에 있는 지 없는지 비교
{

    player0_value = jokbo[concat_player0];
    
    
    //Console.WriteLine(concat_player0+"존재합니다.");

}
else
{
    player0_value = (non_jokbo[player0[0]] + non_jokbo[player0[1]]) %10;
    

}

Console.WriteLine(player0_value);

//to do 비교, 컴퓨터값 넣기


if (jokbo.ContainsKey(concat_computer1))            //족보에 있는 지 없는지 비교
{

    int computer1_value = jokbo[concat_computer1];

    //Console.WriteLine(concat_computer1 + "존재합니다.");
}






