//using System;


//참고했던 코드들





////gpt피셜 코드
//using System;
//using System.Collections.Generic;

//class Item
//{
//    public int Id;
//    public bool IsEquipped;
//    public string Name;
//    public string StatText;
//    public string Description;

//    public Item(int id, bool isEquipped, string name, string statText, string description)
//    {
//        Id = id;
//        IsEquipped = isEquipped;
//        Name = name;
//        StatText = statText;
//        Description = description;
//    }

//    public override string ToString()
//    {
//        string equipSymbol = IsEquipped ? "[E]" : "";
//        return $"{Id} {equipSymbol}{Name} | {StatText} | {Description}";
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        List<Item> inventory = new List<Item>();

//        inventory.Add(new Item(1, true, "무쇠갑옷", "방어력 +5", "무쇠로 만들어져 튼튼한 갑옷입니다."));
//        inventory.Add(new Item(2, true, "스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다."));
//        inventory.Add(new Item(3, false, "낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다."));

//        Console.WriteLine("[아이템 목록]");
//        foreach (var item in inventory)
//        {
//            Console.WriteLine("- " + item.ToString());
//        }

//        Console.ReadKey(); // 콘솔 꺼짐 방지
//    }
//}


//using System;
//using System.Collections.Generic;

//class Item
//{
//    //get 으로 읽고 set 값을 수정한다  
//    public string Name { get; set; }

//    public int Count { get; set; }


//    public Item(string name, int count)
//    {
//        Name = name;
//        Count = count;
//    }


//    //아이템 사용하기
//    public void Use()
//    {
//        if (Count > 0)
//        {
//            Count--;
//            Console.WriteLine($"{Name}을 사용했습니다 남은개수 {Count}");
//        }
//        else
//        {
//            Console.WriteLine($"{Name}은 더이상 없습니다");

//        }
//    }

//    public void DisPlay()
//    {
//        Console.WriteLine($"{Name}을 사용했습니다 남은개수 {Count}");
//    }
//}


//class RPGGame
//{
//    static void Main()
//    {

//        //바퀴를 새로만들지말아라
//        List<Item> inventory = new List<Item>
//        {
//            //0 1 2 3 


//            new Item("회복약",5),
//            new Item("목검",1),
//            new Item("지도",1),
//            new Item("마법약",3)
//        };

//        Console.WriteLine("========아이템============");

//        foreach (var item in inventory)
//        {
//            item.DisPlay();
//        }

//        Console.WriteLine("========아이템사용============");

//        bool UseItem = true;


//        while (UseItem)
//        {
//            Console.WriteLine("사용할 아이템을 선택해주세요: ");

//            for (int i = 0; i < inventory.Count; i++)
//            {
//                Console.WriteLine($"{i}: {inventory[i].Name} 남은개수:{inventory[i].Count} ");
//            }

//            Console.Write("아이템 번호를 입력하거나 종료하려면 -1을 입력해주세요: ");

//            //대입연산자
//            //같은 형끼리만 가능하다 
//            int selectIndex = int.Parse(Console.ReadLine());

//            if (selectIndex == -1)
//            {
//                UseItem = false;
//            }
//            //아이템 범위 내에서 
//            else if (selectIndex >= 0 && selectIndex < inventory.Count)
//            {
//                inventory[selectIndex].Use();
//            }
//            else
//            {
//                Console.WriteLine("잘못된 번호입니다!");
//            }
//        }

//        Console.WriteLine("\n==아이템 추가기능=====");
//        Console.WriteLine("아이템 추가하시겠습니까?");
//        Console.ReadLine();

//        string addchoice = Console.ReadLine();

//        if (addchoice.ToLower() == "y")
//        {
//            Console.Write("아이템 이름: ");
//            string newname = Console.ReadLine();

//            bool exists = false;

//            foreach (var item in inventory)
//            {
//                if (item.Name == newname)
//                {
//                    exists = true;
//                    Console.WriteLine("이미 존재하는 아이템입니다");
//                    break;
//                }
//            }

//            if (!exists)
//            {
//                Console.Write("아이템 개수: ");
//                int newCount = int.Parse(Console.ReadLine());
//                inventory.Add(new Item(newname, newCount));
//                Console.WriteLine($"{newname}이 인벤토리에 추가되었습니다!");
//            }
//        }
//        Console.WriteLine("==인벤토리==");
//        foreach (var item in inventory)
//        {
//            item.DisPlay();
//        }

//        Console.ReadLine();
//    }
//}










//namespace CSharpDay;
//이재현튜터님  코드
//class Program
//{
//    static void Main(string[] args)
//    {
//        var gameLogic = new GameLogic();
//        gameLogic.StartGame();
//    }
//}

//class GameLogic
//{
//    private Player _player;
//    private bool _isGameOver = false;

//    public void StartGame()
//    {
//        Init();

//        while (!_isGameOver)
//        {
//            InputHandler();
//        }

//        Console.WriteLine("게임이 종료되었습니다.");
//    }

//    private void InputHandler()
//    {
//        var input = Console.ReadKey(true);
//        if (input.Key == ConsoleKey.Escape)
//        {
//            _isGameOver = true;
//        }
//    }

//    private void Init()
//    {
//        Console.Clear();
//        Console.WriteLine("스파르타 던전에 오신것을 환영합니다.\n이름을 입력하세요.");
//        string? playerName = Console.ReadLine();

//        if (string.IsNullOrEmpty(playerName))
//        {
//            Console.WriteLine("잘못된 이름입니다.");
//            Thread.Sleep(1000);
//            Init(); // 실제로 이렇 사용하시면 않됨, 재귀호출
//        }
//        else
//        {
//            _player = new Player(playerName);
//            Console.WriteLine($"{_player.name}님, 입장하셨습니다.");
//        }

//        // 직업선택
//        Console.WriteLine("직업을 선택하세요. [1:전사 | 2:법사 | 3:궁수]");
//        int job = int.Parse(Console.ReadLine());

//        if (job >= 1 && job <= 3)  // if (job is >=1 and <=3) 패턴매칭 C# 9.0 ?
//        {
//            _player.job = (Job)job;

//            switch (_player.job)
//            {
//                case Job.Warrior:
//                    Console.WriteLine($"{_player.job}를 선택했습니다.");
//                    break;
//                case Job.Wizzard:
//                    Console.WriteLine($"{_player.job}를 선택했습니다.");
//                    break;
//                case Job.Archor:
//                    Console.WriteLine($"{_player.job}를 선택했습니다.");
//                    break;
//            }
//        }
//    }
//}

//class Player
//{
//    public string name;
//    public Job job;

//    public Player(string name)
//    {
//        this.name = name;
//    }
//}

//public enum Job
//{
//    Warrior = 1,
//    Wizzard,
//    Archor
//}