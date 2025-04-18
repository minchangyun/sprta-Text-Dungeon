using System.ComponentModel.Design;
using System.Diagnostics;

namespace text_d
{
    /*
    필수기능 - 게임 시작화면, 상태보기, 인벤토리, 장착관리, 상점, 아이템 구매,


                                                                         /
     개인과제 진행중 챗gpt와 튜터님 강의내용 이용 하였습니다.           /=====================중요?
   보이실진 모르겠지만 class1 에 활용한 코드 전문을 넣어두긴 했습니다.  \=====================
                                                                          \








    도전기능
    장비의 타입으로 가죽, 사슬갑옷 동시착용 가능/ 플레이트 갑옷 타갑옷과 중복장착 불가능, 장비는 풀세드(투구, 바?지, 신발 등 포함 - 비쌀예정 
    두손무기 - 다른무기와 중복장착 불가능 한손무기와의 차별점이 필요  =  롱소드나 클레이모어같은 칼, 두손도끼, 창, 평균 무게 3
    한손무기 - 두개의 장비를 동시에 들 수 있음, 한손무기 두개 가능, 단창, 단검, 레이피어 무게 개당 2
    방패추가 - 방패의 무게비례 방어력 증가기능 - 던전 클리어용 
    활 - 모든무기와 중복착용 가능, 활끼리는 x 던전에 들어갈때마다 일정 골드를 화살값으로 소모하지만 던전 클리어 확률 3%~10%?증가 - 아이템 취급?
    소모성 아이템 - 횃불 던전 클리어 확률 증가. 포션 - 1개만 소지가능

    숙련도 시스템 - 던전을 한번 돌때마다 10%씩 상승, 기본 낡은철검 숙련도 50, 구매한 아이템들은 숙련도 0부터 시작, 숙련도 20이하는 공격력 10%감소 
    숙련도 20~50은 기본공격력, 숙련도 50~70 공격력 10%상승, 숙련도 70~100은 공격력 20% 증가, 다루기 힘든무기들은 숙련도 조정


    특수스텟? - 힘 or 무게 = 15로?
    장비를 착용할때 필요


    아이템 - 소모성과 장비로 나누고 

    */
    


    class GameLogic
    {
        private Player player;
        private bool IsGameOver = false;

        public void StartGame()
        {
            Init();

            while (!IsGameOver)
            {
                InputHandler();
            }

            Console.WriteLine("게임이 종료되었습니다.");
        }


        private void InputHandler()
        {
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
            {
                IsGameOver = true;
            }
            
        }
        public void BackToTown()
        {
            while (true)
            {
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.D0 || input.Key == ConsoleKey.NumPad0)
                {
                    Console.WriteLine(" 마을로 이동합니다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine(" 현재 위치는 마을입니다.무엇을 하시겠습니까?");
                    Console.WriteLine(" 1.상태창 \n 2.인벤토리 \n 3.장비창 \n 4.상점 \n 5.던전 \n 6.휴식하기 \n 0.마을");
                    GTPlace();
                    break;
                }
                else
                {
                    Console.WriteLine(" 마을로 돌아가려면 0번을 누르세요.");
                }
            }
            
        }

        public void ShowStatus()
        {
            Console.WriteLine(" 상태창으로 이동합니다.");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine(" 상태창을 표시합니다.");
            Console.WriteLine($"  이름  : {player.name}");
            Console.WriteLine($"  레벨  : {player.LV}");
            Console.WriteLine($" 공격력 : {player.AP}");
            Console.WriteLine($" 방어력 : {player.DP}");
            Console.WriteLine($"  체력  : {player.HP}");
            Console.WriteLine($"  골드  : {player.Gold}");
            Console.WriteLine($"  무게  : {player.WP}");
            Console.WriteLine(" 마을로 돌아가기 - 0");
            BackToTown();
        }

        public void ShowEquipm()
        {
            Console.WriteLine(" 장비창으로 이동합니다.");
            Thread.Sleep(1000);
            Console.Clear();

            BackToTown();
        }
        public void ShowInven()
        {
            Console.WriteLine(" 인벤토리로 이동합니다.");
            Thread.Sleep(1000);
            Console.Clear();

            BackToTown();
        }

        public void GTShop()
        {
            Console.WriteLine(" 상점으로 이동합니다.");
            Thread.Sleep(1000);
            Console.Clear();

            BackToTown();
        }

        public void GTDungeon()
        {
            if (player.WP >= 15)
            {
                Console.WriteLine(" 짐이 너무 많습니다. 마을로 돌아가서 재정비하세요.(무게 15 이하)");
                BackToTown();
            }
            else if(player.WP < 25 && player.WP >= 0)
            {
                Console.WriteLine(" 던전으로 이동합니다.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(" A Few Momunts Later");
                Thread.Sleep(5000);
                Console.Clear();
                ClearDungeon();
                Console.WriteLine("던전 클리어!\n 마을로 돌아갑니다.");
                BackToTown();
            }

            
        }

        public void ClearDungeon()
        {
            player.Gold += ( 1000 + player.AP * (2/10));
            player.Exp +=1;
        }
        public void TakeARest()
        {
            if (player.HP < 100)
            {
                player.HP = 100;
                player.Gold -= 500;
                Console.WriteLine("체력이 회복되었습니다.");
            }
            else if (player.HP >= 100)
            {
                Console.WriteLine("체력이 충분합니다.");
            }
            GTPlace();
        }


        public void GTPlace()
        {
 
            int? Placenum = int.Parse(Console.ReadLine());

            if (Placenum >0 && Placenum <= 6)
            {
                Place selectedPlace = (Place)Placenum;

                switch (selectedPlace)
                {
                    case Place.상태창:
                        ShowStatus();         
                        break;

                    case Place.인벤토리:
                        ShowInven();
                        break;

                    case Place.장비창:
                        ShowEquipm();
                        break;

                    case Place.상점:
                        GTShop();
                        break;

                    case Place.던전:
                        GTDungeon();
                        break;
                    case Place.휴식하기:
                        TakeARest();
                        break;

                }
                BackToTown();
            }
        }


        private void Init()
        {
            Console.Clear();
            Console.WriteLine("뭐냐, 이 던전에 신입이냐?");
            Console.WriteLine("신입. 이름은 뭐냐");
            string? playerName = Console.ReadLine();

            if (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("뭣같은 이름이구먼.다른 별명같은건 없나?");
                Thread.Sleep(1000);
                Init();
            }
            else
            {
                player = new Player(playerName);
                Console.WriteLine($"그래, {player.name}이라고? 던전에서 무리하지 말고 욕심은 적당히 부리라고.선배가 하는 조언이다.");
            }

            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("현재 위치는 마을입니다.무엇을 하시겠습니까?");
            Console.WriteLine(" 1.상태창 \n 2.인벤토리 \n 3.장비창 \n 4.상점 \n 5.던전 \n 6.휴식하기 \n 0.마을"); ;
            GTPlace();
        }

    }


    public class Player
    {
        public string name;
        
        public int AP = 10;
        public int DP = 5;
        public int HP = 100;
        public int Gold = 1000;
        public int WP = 0;
        public int Exp = 5;
        public int LV => Exp / 5;
        public Player(string name)
        {
            this.name = name;
        }
    }
    public class Inventory
    {
        
    }


    public enum Place
    {
        마을,
        상태창 = 1,
        인벤토리,
        장비창,
        상점,
        던전,
        휴식하기
    }

    class Item
    {
        public string Name { get; set; }
        public int Ap { get; set; }
        public int Dp { get; set; }
        public int Wp { get; set; }
        public int Value { get; set; }
        public string Tjfaud { get; set; }

        public Item( string name, int ap, int dp, int wp, int value, string tjfaud)
        {
            Name = name;
            Ap = ap;
            Dp = dp;
            Wp = wp;
            Value = value;
            Tjfaud = tjfaud;

        }
        //public int Id;
        //public bool IsEquipm;
        //public bool InInven;
        //public string Name;
        //public int Ap;
        //public int Dp;
        //public int Wp;
        //public int Gold;
        //public string tjfaud;
        //public Item(int ItemNum, bool 장비, bool 유무, string 아이템이름,int 공격력, int 방어력, int 무게, int 골드 , string 설명)
        //{
        //    Id = ItemNum;
        //    IsEquipm = /* 유비 관우 */ 장비;
        //    InInven = 유무;//초밥아님
        //    Name = 아이템이름;
        //    Ap = 공격력;
        //    Dp = 방어력;
        //    Wp = 무게;
        //    Gold = 골드;
        //    tjfaud = 설명;
        //}

    }

    //class Amor : Item
    //{

    //}
    //class Weaphon : Item
    //{

    //}
    //class CsItem : Item //class ConsumableItem : Item = 소모품
    //{

    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameLogic = new GameLogic();
            gameLogic.StartGame();


            List<Item> items = new List<Item>
            {
                 new Item( "낡은 철검", 5 , 0 , 3 , 100 , " 집안 창고에 대대로 내려져오던 철검이다."),
                 new Item( "낡은 가죽갑옷", 0, 5, 2, 100 , " 철검과 함께 창고를 지키던 갑옷."),
                 new Item( "롱소드", 9 , 1 , 5, 1500, " 드워프제라 튼튼하다.")

            };






            //List<Item> inventory = new List<Item>();

            //inventory.Add(new Item(1, false, true, "낡은 철검", 5 , 0 , 3 , 100 , "집안 창고에 대대로 내려져오던 철검이다."));
            //inventory.Add(new Item(2, false, true, "낡은 가죽갑옷", 0, 5, 2, 100 , " 철검과 함께 창고를 지키던 갑옷."));
            //inventory.Add(new Item(3, false, false, "롱소드", 9 , 1 , 5, 1500, "대장장이 종족인 드워프가 갖다버린 실패작."));



            //Console.WriteLine("[아이템 목록]");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine("- " + item.ToString());
            //}
        }

    }

}