#include <iostream>
#include <string>
#include <windows.h>
#include <conio.h>
#include <iomanip>
using namespace std;

#pragma region 타입 선언 및 전방 선언
enum CharacterType
{
	PLAYER = 0,
	MONSTER = 1
};

enum PlayerType
{
	PT_Knight = 1,
	PT_Archer = 2,
	PT_Mage = 3,
};

enum MonsterType
{
	MT_Orange_Mushroom = 1,
	MT_Stump = 2,
	MT_Skeleton = 3,
};

struct Character;
struct Dungeon;
struct Player;
struct Game;
struct Monster;
struct Potion;
struct Inventory;
#pragma endregion

#pragma region TextRPG의 속성과 기능

#pragma region 플레이어
struct Character
{
public:
	string name;
	int level;
	int max_hp;
	int hp;
	int atk;

public:
	Character(int characterype)
	{

	}

	~Character()
	{

	}

	virtual void PrintInfo() = 0;
};

struct Player : Character
{
public:
	Player* player;
	Monster* monster;
	int max_mp;
	int mp;
	int max_exp;
	int exp;
	int gold;

	Player(int playertype) : Character(PLAYER)
	{

	}

	virtual ~Player()
	{

	}

	void PrintInfo()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "직업 : " << name << " | 레벨 : " << level << " | 최대 체력 : " << max_hp << " | 현재 체력 : " << hp << " | 최대 마나 : " << max_mp << " | 현재 마나 : " << mp << " | 공격력 : " << atk << " | 최대 경험치 : " << max_exp << " | 현재 경험치 : " << exp << " | 소지금 : " << gold << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}

	void PlayerBattleInfo()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "몬스터와의 전투 행동을 선택 하세요 : [1] 공격 [2] 스킬 [3] 물약 사용 [4] 도망 " << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}

	virtual int Skill(int mp)
	{
		mp -= 20;
		return atk * 2;
	}
};

struct Knight : Player
{
public:
	Knight() : Player(PT_Knight)
	{
		name = "기사";
		level = 1;
		max_hp = 100;
		hp = 100;
		max_mp = 100;
		mp = 100;
		max_exp = 100;
		exp = 0;
		atk = 10;
		gold = 100;
	}

	int Skill(int mp)
	{
		mp -= 20;
		return atk * 2;
	}
};

struct Archer : Player
{
public:
	Archer() : Player(PT_Archer)
	{
		name = "궁수";
		level = 1;
		max_hp = 80;
		hp = 80;
		max_mp = 100;
		mp = 100;
		max_exp = 100;
		exp = 0;
		atk = 12;
		gold = 100;
	}

	int Skill()
	{
		mp -= 20;
		return atk * 2;
	}
};

struct Mage : Player
{
public:
	Mage() : Player(PT_Mage)
	{
		name = "마법사";
		level = 1;
		max_hp = 80;
		hp = 80;
		max_mp = 120;
		mp = 120;
		max_exp = 100;
		exp = 0;
		atk = 10;
		gold = 100;
	}

	int Skill()
	{
		mp -= 20;
		return atk * 2;
	}
};
#pragma endregion

#pragma region 포션
struct Potion
{
public:
	string name = "물약";
	int count = 100;
	int gold = 10;
	Player* player;
};
#pragma endregion

#pragma region 몬스터
struct Monster : Character
{
public:
	Monster* monster;
	Player* player;
	int dropexp;
	int dropgold;

public:
	Monster(int monsterType) : Character(MONSTER)
	{

	}

	void PrintInfo()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "몬스터 이름 : " << name << " | 레벨 : " << level << " | 최대 체력 : " << max_hp << " |현재 체력 : " << hp << " | 공격력 : " << atk << " | 획득 가능한 경험치 : " << dropexp << " | 획득 가능한 골드 : " << dropgold << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}


};

struct Slime : Monster
{
public:
	Slime() : Monster(MT_Orange_Mushroom)
	{
		cout << "                                 @@@@@@@@@@@@@@@@@@@@@@########@@@@@@@@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@@@@@@@@@              @@@@@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@@@@@@@                  @@@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@@@@@@                     @@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@@@                         @@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@                            @@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@                               @@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@                                 @@@@@@@@@@" << endl;
		cout << "                                 @@@@$;                                   @@@@@@@@@" << endl;
		cout << "                                 @@@!                                     @@@@@@@@@" << endl;
		cout << "                                 @@;                                      ~@@@@@@@@" << endl;
		cout << "                                 @@~                                        @@@@@@@" << endl;
		cout << "                                 @*                                         ~$@@@@@" << endl;
		cout << "                                 #                                             @@@@" << endl;
		cout << "                                 #                                              @@@" << endl;
		cout << "                                 #                                              ;@@" << endl;
		cout << "                                 #                                               =@" << endl;
		cout << "                                 # ~          ##                                 ~#" << endl;
		cout << "                                 @!,         ####                ##              , " << endl;
		cout << "                                 @=           ##                ####               " << endl;
		cout << "                                 @@                              ##                " << endl;
		cout << "                                 @@$                                               " << endl;
		cout << "                                 @@@                                               " << endl;
		cout << "                                 @@@@#                                           ,#" << endl;
		cout << "                                 @@@@@@*!*...                                     @" << endl;
		cout << "                                 @@@@@@@;...           .                         #@" << endl;
		cout << "                                 @@@@@@;..                                      @@@" << endl;
		cout << "                                 @@@@@!...                                     @@@@" << endl;
		cout << "                                 @@@@# ,                                 ;!!@@@@@@@" << endl;
		cout << "                                 @@@@-.. .                  .            @@@@@@@@@@" << endl;
		cout << "                                 @@@@ ..                   . .           @@@@@@@@@@" << endl;
		cout << "                                 @@@,..  .                               #@@@@@@@@@" << endl;
		cout << "                                 @@@,...                                 =@@@@@@@@@" << endl;
		cout << "                                 @@@,..                                  =@@@@@@@@@" << endl;
		cout << "                                 @@@,.                 .                 =@@@@@@@@@" << endl;
		cout << "                                 @@@~..   .              .               =@@@@@@@@@" << endl;
		cout << "                                 @@@@ .                          .       =@@@@@@@@@" << endl;
		cout << "                                 @@@@ .            .                     #@@@@@@@@@" << endl;
		cout << "                                 @@@@# .                             -~:!@@@@@@@@@@" << endl;
		cout << "                                 @@@@$,   .   . .     .              -:~@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@#,     .  .  . .               ~-=@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@#.... .. .... ..              ~$@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@..............              =@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@~, .,,,,,,,..,,,,--------!@@@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@==! ...........,,,,,-$$=@@@@@@@@@@@@@@@@" << endl;
		cout << "                                 @@@@@@@@@@@@@##############@###@@@@@@@@@@@@@@@@@@@" << endl;
		cout << endl;

		name = "주황 버섯";
		level = 1;
		max_hp = 40;
		hp = 40;
		atk = 5;
		dropexp = 100;
		dropgold = 10;
	}
};

struct Orc : Monster
{
public:
	Orc() : Monster(MT_Stump)
	{
		cout << "                                @@@@@@@@@@@@###################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ " << endl;
		cout << "                                @@@@@@#$$$$@~- ~::::~!:~~:::::: : = #@$$$$####@@@@@@@@@@@@@@@@@@@ " << endl;
		cout << "                                @@@@@@ * ~::~#~$#!; == :@:::;;;; :; : *#@~~::====#@##@@@@@@@@@@@@ " << endl;
		cout << "                                @@@@@@ = ~;; :##;;;; $ = :!$~::;;; ::: != @:::; ====#@##@@@@@@@@@ " << endl;
		cout << "                                @@@@@@ = #;; :#:: : ; = @# = ; #; ::;;; ::: != = :: : ; ====@@@@@ " << endl;
		cout << "                                @@@@@@#;;; : = *: !*#*, *=; $; ::;; :::: *= ; ::; ====#@##@@@@@@@ " << endl;
		cout << "                                @@@@@@ * :; :::@ = *$ == *= == !$; :; : !::; *= !::; ====#@##@@@@ " << endl;
		cout << "                                @@@@@@@;; :::@; !##, -~$#~#!:; : = :: : # = *: ;; ====####@@@@@@@ " << endl;
		cout << "                                @@@@@@ * :; :::@; ##. . - # = !#;; : = ::; *@ * :;; ====####@@@@@ " << endl;
		cout << "                                @@@@@@ = ; :;; ::; #~~=, , ~#~#;; *$:: * # = *:; !=== = ####@@@@@ " << endl;
		cout << "                                @@@@@@@!: *= : ;; #:.$@ - , :# : $;; !@;; !$# * :; ====$#$$#@@@@@ " << endl;
		cout << "                                @@@@@@@!: *= : ;; #:; *., ~#:*; : = @; :*#$ * : ; ====##$$@@@@@@@ " << endl;
		cout << "                                @@@@@@@!: *= : ;; #@, ., ~@ = :*;; !@;; :*@* :; ====##$$@@@@@@@@@ " << endl;
		cout << "                                @@@@@@@@; : = **!!@$; !; = #~: = ; !#@;;; !@ * : *= == ##@$#@@@@@ " << endl;
		cout << "                                @@@@@@@@; : = # = !; $$*; *= *::#; :!@;;; :$ = : *= = $##@$@@@@@@ " << endl;
		cout << "                                @@@@@@@@; : == : = : ; $ = -**:; : #; !*@:;; : = #; *= $##@$$@@@@ " << endl;
		cout << "                                @@@@@@@@;;; $#;; : = @@ * :; : !@; !@!:;;; !$# == ###@ = @@@@@@@@ " << endl;
		cout << "                                @@@@@@@@ *= :$!;;; :$ = ::;; *#; !@!:!*: @; $@###@ = $@@@@@@@@@@@ " << endl;
		cout << "                                @@@@@@@@@::: = *;;; *= :::; @;; *@; : = *: $ * !#@## = $#@@@@@@@@ " << endl;
		cout << "                                @@@@@@@@!!*::#:;;; !:;; *@!; $ = :; # = :$$!#@##$#@@@@@@@@@@@@@@@ " << endl;
		cout << "                                @@@@@@@@!@@;; # = :;; !:;; #*; = # * :; # = ;; $ = *#@$$@#@@@@@@@ " << endl;
		cout << "                                @@@@@@@@##$*; $ = :;; ::; = #*; $ = :; = @@# == #$#@#@###@@@@@@@@ " << endl;
		cout << "                                @@@@@@@$:::$:!$; : ; :: != #; = #~!= # = $@$ = $####@####@@@@@@@@ " << endl;
		cout << "                                @@@@@@$::; :**; #$;;; : = #; !#!; *@!: *= @# = ##$#####$@@@@@@@@@ " << endl;
		cout << "                                @@@@@@ * ~:: != @ * *= ;;;; = #~*#; = #!:;; = $# = $#$#@##$ = @@@ " << endl;
		cout << "                                @@@@@$~::;; ##$ == = :: * $$; @!!# = ::; *= = ##$@$##### = @@@@@@ " << endl;
		cout << "                                @@@@@$:::: * *= # == = !:*@ : ; @ != $; :: = #@@@#$@#@###@#@@@@@@ " << endl;
		cout << "                                @@@@@@*; ::::#$ == $ * :*@; $ = ; $#~:*!*= $$##@#@###$$@#@@@@@@@@ " << endl;
		cout << "                                @@@@#!$;;; :$ = @# = ##:*!; @ * *#::::: = @@@##@#@#### = @##@@@@@ " << endl;
		cout << "                                @@@@; = #@!;; : = ## = #@!*;; # * *#:::: = *:; *$@@#@##$ == #$#@@ " << endl;
		cout << "                                @@@ = !*; $@:;; *= @$#@ = $;; # * *#:; : ; *~:;; *$@#@######$$@@@ " << endl;
		cout << "                                @@@; :: *= $ = :; : = @$$@ = $; *# * *#: = ; ::::; : != #@####@@@ " << endl;
		cout << "                                @@@!::$ != $:;; = @$ = #$$ == # * *#:#$#:: : ; : != #@##$ = ###$@ " << endl;
		cout << "                                @@@!;; :: = @ * : = $#$###$$ = # *= #~$$#::;; : *= #@##$$@#$$@@@@ " << endl;
		cout << "                                @@@@!$:; *$# != = ##@@#$@$ * @$$ * *##:;; : = ###@######$$@@@@@@@ " << endl;
		cout << "                                @@@@ == *:; $# == $#@@@@@#@#@@#@$ = #:; : $@@@@#$ = ####$$@@@@@@@ " << endl;
		cout << "                                @@@@@#@#; = #####@@$######$@@@@!:*$####@@@@@##$ = @@@@@@@@@@@@@@@ " << endl;
		cout << "                                @@@#$:; : ; = #@@@@@@ = #####$$@@@@;; :*$##@@@@@@##$$@@@@@@@@@@@@ " << endl;
		cout << "                                @$$:~; : !!$@@@@@@ = @$#### = @@@@@;; :::$#@@@@@@##$@###@@@@@@@@@ " << endl;
		cout << "                                #~~:***$$@@@@@@@=####$=#@@@@@:;**!*=$@@@@@@####$*@@@@@@@@@@@@@@@@ " << endl;
		cout << endl;

		name = "스텀프";
		level = 2;
		max_hp = 60;
		hp = 60;
		atk = 10;
		dropexp = 100;
		dropgold = 20;
	}
};

struct Skeleton : public Monster
{
public:
	Skeleton() : Monster(MT_Skeleton)
	{
		cout << "                                      @@@@@@@@@:#@@ = #@@@@@@@@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@@@@@ * .!#@ * *@@@@@@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@@@@@ - .; !:; $@@@@@@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@@@@#, .:$ != !!$@@@@@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@@ ., =~*:-~; : != = @@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@#, =.:::, , ~;; !***@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@~$.; ::; -, ~;; !**$@@@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@: == !- : !- ~; : ; ****$@@@@@@@@@@       " << endl;
		cout << "                                      @@@; , !. = ~; ~:; : ;; !***$@@@@@@@@@@       " << endl;
		cout << "                                      @@@ = ~; = $!*!**!!!*= **#@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@:!!;; !!## == !**= = *#@@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@@ = #$, , #$###; !!#!$ = @@@@@@@@@@@       " << endl;
		cout << "                                      @@@@$# = .~@###$: != $; = $@@@@@@@@@@@@       " << endl;
		cout << "                                      @@@: = # : , ~@##$$!; = ; ~#; *@@@@@@@@       " << endl;
		cout << "                                      @@@, !@~!, ; #$#$, :@@@@@ - *@@@@@@@@@@       " << endl;
		cout << "                                      @@@@!, , -, -~;;; :!$@ = # != :*@@@@@@@       " << endl;
		cout << "                                      @@@@@ = :, :: = # = ##; !#@$;; $~*@@@@@       " << endl;
		cout << "                                      @@@@@@ * -!; # != @@!; @:. - !$@, *@@@@       " << endl;
		cout << "                                      $ = @@@@ - , ~== *@@@$; $@@# * *#$ - @@       " << endl;
		cout << "                                      * -*@@@ * --~; = @@@ *= #@$ == **$ * @@       " << endl;
		cout << "                                      *, ~= *#@@@@@@@@@ = ; , @##!~!@; ~#@@@@       " << endl;
		cout << "                                      !:. : !$@@@@@@@@@ != @ *= !:*@@:*@@@@@@       " << endl;
		cout << "                                      #;-.~*@@@@@@@@$-*$;$@#=@@~;@@@@@@@@@@@@       " << endl;
		cout << "                                      @$$; , :*@@@@@@@~*@@@!!:**@~; @@@@@@@@@       " << endl;
		cout << "                                      @@@$ - , :*$@@@@ * :@@@# = # * !~= !*@@       " << endl;
		cout << "                                      @@@@@*, :#@@@ * ~= @@@$!!; *!@!$@@@@@@@       " << endl;
		cout << "                                      @@@@@@ = -!$$@ = ; = @@@ - !#~#; @!$@@@       " << endl;
		cout << "                                      @@@@@@@@# * :!; @@@; -*@@@:~@!$@@@@@@@@       " << endl;
		cout << "                                      @@@@@@@$~# = $ = @@@@~@@@@ * !*: = @@@@       " << endl;
		cout << "                                      @@@@@@@@; # * $ = @@ = !- @@@@ = != *@@       " << endl;
		cout << "                                      @@@@@@@@@# * $$@@@@; = @@@@@# * #@$# @@       " << endl;
		cout << "                                      @@@@@@@@@@@ = @@@ = $ = *#@@@@ * !; @@@       " << endl;
		cout << "                                      @@@@@@@@@@@@@@@ = *= #$@@@@ == # * *$@@       " << endl;
		cout << endl;

		name = "스켈레톤";
		level = 3;
		max_hp = 80;
		hp = 80;
		atk = 15;
		dropexp = 100;
		dropgold = 30;
	}
};
#pragma endregion

#pragma region 던전
struct Dungeon
{
public:
	Monster* monster;

public:
	Dungeon() : monster(nullptr)
	{

	}

	~Dungeon()
	{
		if (monster != nullptr)
		{
			delete monster;
		}
	}

	void CreateMonster()
	{
		int randValue = 1 + rand() % 3;

		switch (randValue)
		{
		case MT_Orange_Mushroom :
			monster = new Slime();
			break;
		case MT_Stump:
			monster = new Orc();
			break;
		case MT_Skeleton:
			monster = new Skeleton();
			break;
		}
	}
};
#pragma endregion

#pragma endregion

#pragma region TextRPG
// 게임의 주요 기능및 게임 시작
struct Game
{
public:
	Player* player;
	Monster* monster;
	Dungeon* dungeon;
	Inventory* inventory;
	Potion potion;

public:
	Game() : player(nullptr), dungeon(nullptr)
	{

	}
	~Game()
	{
		if (player != nullptr)
		{
			delete player;
		}

		if (dungeon != nullptr)
		{
			delete dungeon;
		}

		delete inventory;
	}

	// 게임의 초기화시 던전 생성
	void Init()
	{
		dungeon = new Dungeon;
	}

	// 게임의 시작 오프닝 씬부터 시작
	void Update()
	{
		if (player == nullptr)
		{
			OpeningScene();
		}
	}

	// 게임의 틀을 구성하고 Text를 간편하게 출력하기 위한 함수
	void PrintMessage(const char* msg)
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "                                                   " << msg << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}

	void OpeningScene()
	{
		cout << "\n\n\n\n\n\n\n\n\n" << endl;
		cout << "                                 ######  ######  ##  ##  ######    #####    #####    ##### " << endl;
		cout << "                                   ##    ##      ##  ##    ##      ##  ##   ##  ##  ##     " << endl;
		cout << "                                   ##    ######   ####     ##      ##  ##   ##  ##  ##     " << endl;
		cout << "                                   ##    ######   ####     ##      ##  ##   ##  ##  ##     " << endl;
		cout << "                                   ##    ##       ####     ##      #####    #####   ## ### " << endl;
		cout << "                                   ##    ##      ##  ##    ##      ## ##    ##      ##  ## " << endl;
		cout << "                                   ##    ######  ##  ##    ##      ##  ##   ##       ##### " << endl;
		Sleep(3000);
		system("cls");

		PrintMessage("당신은 TextRPG에 진입했습니다.");
		PrintMessage("몬스터를 물리쳐 강해지십시오");
		Sleep(3000);
		system("cls");

		CreatePlayer();
	}

	// 동적할당을 이용한 랜덤한 몬스터 생성
	void CreatePlayer()
	{
		while (player == nullptr)
		{
			PrintMessage("캐릭터를 생성하세요 !!");
			PrintMessage("\n[1] : 기사 (체력 : 100 마나 : 50 공격력 : 10) \n[2] : 궁수 (체력 : 80 마나 : 100 공격력 : 12)\n[3] : 마법사(체력 : 80 마나 : 120 공격력 : 10)\n");

			char input;
			input = _getch();

			if (input == '1')
			{
				player = new Knight();
			}
			else if (input == '2')
			{
				player = new Archer();
			}
			else if (input == '3')
			{
				player = new Mage();
			}
			else
			{
				PrintMessage("다시 입력하세요");
				CreatePlayer();
			}
		}

		PrintMessage("생성 완료 마을로 이동합니다.");
		Sleep(1000);
		system("cls");
		EnterVillage();
	}

	void EnterVillage()
	{
		PrintMessage("마을에 입장했습니다");
		Sleep(1000);
		GameManager();
	}

	void GameManager()
	{
		char input;
		system("cls");
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "마을입니다 어디로 가시겠습니까 ? [1] : 던전, [2] : 상점" << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;

		input = _getch();

		if (input == '1')
		{
			PrintMessage("던전으로 이동");
			Sleep(1000);
			system("cls");
			EnterDungeon();
		}
		else if (input == '2')
		{
			PrintMessage("상점으로 이동");
			Sleep(1000);
			EnterStore();
		}
		else
		{
			PrintMessage("다시 입력하세요");
			GameManager();
		}
	}

	void EnterStore()
	{
		PrintMessage("상점에 입장했습니다");

		char input;
		system("cls");
		cout << "상점 : [1]은 물약 구매, [2]는 인벤토리 확인 , [3]은 마을로 돌아가기" << endl;
		input = _getch();



		if (input == '1')
		{
			PrintMessage("물약을 구매했습니다.");
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "현재 소지금 : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			addItem();
			Sleep(1000);
			EnterStore();
		}
		else if (input == '2')
		{
			PrintMessage("인벤토리를 확인합니다.");
			Sleep(1000);
			showInventory();
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "현재 소지금 : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			Sleep(1000);
			EnterStore();

		}
		else if (input == '3')
		{
			PrintMessage("마을로 돌아가기");
			Sleep(1000);
			EnterVillage();
		}
		else
		{
			PrintMessage("다시 입력하세요");
			EnterStore();
		}
	}

	void EnterDungeon()
	{
		PrintMessage("던전에 입장했습니다.");
		PrintMessage("현재 내 정보");
		player->PrintInfo();		

		char input;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "행동을 선택하세요  [1] : 랜덤한 몬스터와 전투, [2] : 인벤토리 확인 , [3] : 마을로 돌아가기" << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		input = _getch();

		if (input == '1')
		{
			PrintMessage("랜덤한 몬스터와 전투");
			Sleep(1000);
			system("cls");
			EnterBattle();
		}
		else if (input == '2')
		{
			PrintMessage("인벤토리를 확인합니다.");
			Sleep(1000);
			showInventory();
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "현재 소지금 : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			Sleep(2000);
			system("cls");
			EnterDungeon();
		}
		else if (input == '3')
		{
			PrintMessage("마을로 이동");
			Sleep(1000);
			system("cls");
			EnterVillage();
		}
		else
		{
			PrintMessage("다시 입력하세요");
			system("cls");
			EnterDungeon();
		}
	}

	void PlayerTurn(Player* player, Monster* monster)
	{
		char input;
		input = _getch();

		if (input == '1')
		{
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "플레이어가 몬스터를 공격했습니다. " << player->atk << "의 데미지를 주었습니다." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			monster->hp -= player->atk;
			player->PrintInfo();
			monster->PrintInfo();

			if (monster->hp <= 0)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "몬스터를 처치했습니다.랜덤한 다른 몬스터를 조우합니다." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				player->gold += monster->dropgold;
				player->exp += monster->dropexp;
				player->max_mp += 10;
				Sleep(5000);
				system("cls");
				EnterBattle();
			}
			if (monster->hp > 0)
			{
				MonsterTurn(player, monster);
				PlayerTurn(player, monster);
			}
		}
		if (input == '2' && player->mp >= 20)
		{
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "플레이어가 스킬을 사용해 공격했습니다. " << player->Skill(player->mp) << "의 데미지를 주었습니다." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			monster->hp -= player->Skill(player->mp);
			player->mp -= 20;
			player->PrintInfo();
			monster->PrintInfo();

			if (monster->hp <= 0)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "몬스터를 처치했습니다.랜덤한 다른 몬스터를 조우합니다." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				player->gold += monster->dropgold;
				player->exp += monster->dropexp;
				player->max_mp += 10;
				Sleep(5000);
				system("cls");
				EnterBattle();
			}
			if (monster->hp > 0)
			{
				MonsterTurn(player, monster);
				PlayerTurn(player, monster);
			}
		}
		if (input == '2' && player->mp < 20)
		{
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "플레이어의 마나가 부족합니다. 다른 행동을 선택해 주세요." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			PlayerTurn(player, monster);
		}
		if (input == '3')
		{
			if (player->max_hp <= player->hp)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "최대 체력입니다. 물약을 사용할 수 없습니다. 다른 행동을 선택해 주세요." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
				PlayerTurn(player, monster);
			}
			else
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "물약을 사용 합니다." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
				hpUp();
				potion.count--;
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "물약이 " << potion.count << "개 남았습니다." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;				
				player->PrintInfo();
				monster->PrintInfo();
			}

			if (monster->hp > 0)
			{
				MonsterTurn(player, monster);
				PlayerTurn(player, monster);
			}

		}
		if (input == '4')
		{
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "몬스터와의 전투에서 도망갑니다." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			Sleep(1000);
			system("cls");
			EnterDungeon();
		}		
	}

	void MonsterTurn(Player* player, Monster* monster)
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "몬스터가 플레이어를 공격했습니다. " << monster->atk << "의 데미지를 받았습니다." << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
		player->hp -= monster->atk;

		if (player->hp <= 0)
		{
			GameOverScene();
		}
	}

	void EnterBattle()
	{
		// 랜덤한 몬스터 생성
		dungeon->CreateMonster();
		// 생성한 몬스터를 대입
		monster = dungeon->monster;
		LevelUp();
		// 몬스터의 정보
		monster->PrintInfo();
		// 내 정보
		player->PlayerBattleInfo();	
		PlayerTurn(player, monster);
	}

	void GameOverScene()
	{
		system("cls");
		PrintMessage("사망하셨습니다. 게임 처음으로 돌아갑니다.");
		Sleep(1000);
		OpeningScene();
	}

	void addItem()
	{
		potion.count++;
		player->gold -= potion.gold;
	}

	// 인벤토리 보기 함수
	void showInventory()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "인벤토리 목록 : 물약이 " << potion.count << "개 남았습니다." << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}

	void hpUp()
	{
		if (player->hp >= 80 && player->hp <= 100)
		{
			player->hp = 100;
		}
		player->hp += 20;
	}

	void LevelUp()
	{
		if (player->exp>=100)
		{
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "                                       ##      ##          ##   ##     ##   #######"                                      << endl;
			cout << "                                       ##       ##        ##    ##     ##   ##    ##"                                     << endl;
			cout << "                                       ##        ##      ##     ##     ##   ##    ##"                                     << endl;
			cout << "                                       ##         ##    ##      ##     ##   ##    ##"                                     << endl;
			cout << "                                       ##          ##  ##       ##     ##   #######"                                      << endl;
			cout << "                                       ##           ####        ##     ##   ##"                                           << endl;
			cout << "                                       ########      ##          #######    ##"                                           << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			player->level++;
			player->max_hp += 20;
			player->hp += 20;
			player->max_mp += 20;
			player->mp += 20;
			player->atk += 3;
			player->exp = 0;	
			player->hp = player->max_hp;
			player->mp = player->max_mp;
		}	
	}
};
#pragma endregion

// 메인 함수
int main()
{
	// cmd의 제목을 바꿔준다.
	system("title TextRPG");
	// 몬스터를 랜덤으로 생성하기 위해 사용한 랜덤함수
	srand((unsigned)time(0));

	Game game;
	game.Init();    // 게임의 주요 기능을 초기화 하고시작

	while (true)
	{
		game.Update();  // 게임을 쭉 하기 위해 반복문사용
	}

	return 0;
}





