
//                  0     1     2      3      4       5      6      7
using System;
                    
string[] deck = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                 "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                 "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                 "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

List<string> mycard = new List<string>();
List<int> mycard_onlynum = new List<int>();
List<string> mycard_onlyshape = new List<string>();

Random rand = new Random();

List<int> randnum_list = new List<int>();

for (int i = 0; i < 5;)
{
    int randnum = rand.Next(0, 32);

    if (!randnum_list.Contains(randnum))
    {
        
        randnum_list.Add(randnum);
        i++;        
    }
    
}

mycard.Add(deck[randnum_list[0]]); // 11d
mycard.Add(deck[randnum_list[1]]); // 08s
mycard.Add(deck[randnum_list[2]]); // 12c
mycard.Add(deck[randnum_list[3]]);// 08d
mycard.Add(deck[randnum_list[4]]);// 06d

Console.WriteLine(mycard[0] + " " + mycard[1] + " " + mycard[2]+" " + mycard[3]+
                    " " + mycard[4]);

for(int i=0; i<mycard.Count; i++)
{
    mycard_onlynum.Add(Convert.ToInt32(mycard[i].Substring(0, 2)));
    
}

for (int i = 0; i < mycard.Count; i++)
{
    mycard_onlyshape.Add(mycard[i].Substring(2,1));
    //Console.WriteLine(mycard_onlyshape[i]);
}
mycard_onlynum.Sort();
mycard_onlyshape.Sort();

bool isflush = false;
bool ismount = false;

//플러쉬 인지 확인 : 정렬 후 맨앞카드와 맨뒷카드가 같으면 플러쉬
if (mycard_onlyshape[0]== mycard_onlyshape[mycard_onlyshape.Count - 1])
{
    isflush = true;
}


// 마운틴 확인 : 정렬 후  A 10 J Q K 라면 마운틴 
if((mycard_onlynum[0]==6) && (mycard_onlynum[1]==10) && (mycard_onlynum[2] == 11)&&
    (mycard_onlynum[3] == 12) && (mycard_onlynum[4] == 13))
{
    ismount = true;
    
}


bool isstraight = false;

//stright 확인 : 정렬 후 i +1의 숫자가 현재 i와 같다면 true 한번이라도 같지않다면 false 후 break
for (int i = 0; i < mycard_onlynum.Count-1; i++)
{
    if(mycard_onlynum[i+1] - mycard_onlynum[i] == 1)
    {
        isstraight = true;
        
    }
    else
    {
        isstraight = false;
        break;
    }

}

//paircount = 원페어 : 1, 투페어 : 2, 트리플 : 3 , 플러쉬 : 4, 포카드 :6 
int paircount = 0;

for(int i =0; i<mycard_onlynum.Count-1; i++)
{
    for(int j=i+1; j< mycard_onlynum.Count; j++)
    {
        

        if (mycard_onlynum[i] == mycard_onlynum[j])
        {
            paircount++;
        }

    }

}


if (isflush && ismount)
{
    Console.WriteLine("축하합니다. 로티플이에요");
}
else if (isflush && isstraight)
{
    Console.WriteLine("축하합니다 스트레이트 플러쉬에요");
}
else if (paircount == 6)
{
    Console.WriteLine("축하합니다 포카드입니다.");
}
else if (paircount == 4)
{
    Console.WriteLine("축하합니다 풀하우스에요.");
}
else if (isflush) 
{
    Console.WriteLine("축하합니다 플러쉬에요");
}
else if (ismount)
{
    Console.WriteLine("축하합니다 마운틴입니다.");
}
else if (isstraight)
{
    Console.WriteLine("축하합니다 스트레이트입니다.");
}
else if (paircount==3)
{
    Console.WriteLine("축하합니다 트리플입니다.");
}
else if (paircount==2)
{
    Console.WriteLine("아쉽네요 투페어");
}
else if (paircount==1)
{
    Console.WriteLine("아쉽네요 원페어");
}
else
{
    Console.WriteLine("아무것도 아닌 탑카드에요");
}

