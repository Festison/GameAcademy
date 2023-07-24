#include <iostream>
#include <string>
#include <windows.h>
#include <conio.h>
#include <iomanip>
using namespace std;

#pragma region Ÿ�� ���� �� ���� ����
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

#pragma region TextRPG�� �Ӽ��� ���

#pragma region �÷��̾�
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
		cout << "���� : " << name << " | ���� : " << level << " | �ִ� ü�� : " << max_hp << " | ���� ü�� : " << hp << " | �ִ� ���� : " << max_mp << " | ���� ���� : " << mp << " | ���ݷ� : " << atk << " | �ִ� ����ġ : " << max_exp << " | ���� ����ġ : " << exp << " | ������ : " << gold << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
	}

	void PlayerBattleInfo()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "���Ϳ��� ���� �ൿ�� ���� �ϼ��� : [1] ���� [2] ��ų [3] ���� ��� [4] ���� " << endl;
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
		name = "���";
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
		name = "�ü�";
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
		name = "������";
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

#pragma region ����
struct Potion
{
public:
	string name = "����";
	int count = 100;
	int gold = 10;
	Player* player;
};
#pragma endregion

#pragma region ����
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
		cout << "���� �̸� : " << name << " | ���� : " << level << " | �ִ� ü�� : " << max_hp << " |���� ü�� : " << hp << " | ���ݷ� : " << atk << " | ȹ�� ������ ����ġ : " << dropexp << " | ȹ�� ������ ��� : " << dropgold << endl;
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

		name = "��Ȳ ����";
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

		name = "������";
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

		name = "���̷���";
		level = 3;
		max_hp = 80;
		hp = 80;
		atk = 15;
		dropexp = 100;
		dropgold = 30;
	}
};
#pragma endregion

#pragma region ����
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
// ������ �ֿ� ��ɹ� ���� ����
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

	// ������ �ʱ�ȭ�� ���� ����
	void Init()
	{
		dungeon = new Dungeon;
	}

	// ������ ���� ������ ������ ����
	void Update()
	{
		if (player == nullptr)
		{
			OpeningScene();
		}
	}

	// ������ Ʋ�� �����ϰ� Text�� �����ϰ� ����ϱ� ���� �Լ�
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

		PrintMessage("����� TextRPG�� �����߽��ϴ�.");
		PrintMessage("���͸� ������ �������ʽÿ�");
		Sleep(3000);
		system("cls");

		CreatePlayer();
	}

	// �����Ҵ��� �̿��� ������ ���� ����
	void CreatePlayer()
	{
		while (player == nullptr)
		{
			PrintMessage("ĳ���͸� �����ϼ��� !!");
			PrintMessage("\n[1] : ��� (ü�� : 100 ���� : 50 ���ݷ� : 10) \n[2] : �ü� (ü�� : 80 ���� : 100 ���ݷ� : 12)\n[3] : ������(ü�� : 80 ���� : 120 ���ݷ� : 10)\n");

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
				PrintMessage("�ٽ� �Է��ϼ���");
				CreatePlayer();
			}
		}

		PrintMessage("���� �Ϸ� ������ �̵��մϴ�.");
		Sleep(1000);
		system("cls");
		EnterVillage();
	}

	void EnterVillage()
	{
		PrintMessage("������ �����߽��ϴ�");
		Sleep(1000);
		GameManager();
	}

	void GameManager()
	{
		char input;
		system("cls");
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "�����Դϴ� ���� ���ðڽ��ϱ� ? [1] : ����, [2] : ����" << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;

		input = _getch();

		if (input == '1')
		{
			PrintMessage("�������� �̵�");
			Sleep(1000);
			system("cls");
			EnterDungeon();
		}
		else if (input == '2')
		{
			PrintMessage("�������� �̵�");
			Sleep(1000);
			EnterStore();
		}
		else
		{
			PrintMessage("�ٽ� �Է��ϼ���");
			GameManager();
		}
	}

	void EnterStore()
	{
		PrintMessage("������ �����߽��ϴ�");

		char input;
		system("cls");
		cout << "���� : [1]�� ���� ����, [2]�� �κ��丮 Ȯ�� , [3]�� ������ ���ư���" << endl;
		input = _getch();



		if (input == '1')
		{
			PrintMessage("������ �����߽��ϴ�.");
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "���� ������ : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			addItem();
			Sleep(1000);
			EnterStore();
		}
		else if (input == '2')
		{
			PrintMessage("�κ��丮�� Ȯ���մϴ�.");
			Sleep(1000);
			showInventory();
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "���� ������ : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			Sleep(1000);
			EnterStore();

		}
		else if (input == '3')
		{
			PrintMessage("������ ���ư���");
			Sleep(1000);
			EnterVillage();
		}
		else
		{
			PrintMessage("�ٽ� �Է��ϼ���");
			EnterStore();
		}
	}

	void EnterDungeon()
	{
		PrintMessage("������ �����߽��ϴ�.");
		PrintMessage("���� �� ����");
		player->PrintInfo();		

		char input;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "�ൿ�� �����ϼ���  [1] : ������ ���Ϳ� ����, [2] : �κ��丮 Ȯ�� , [3] : ������ ���ư���" << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		input = _getch();

		if (input == '1')
		{
			PrintMessage("������ ���Ϳ� ����");
			Sleep(1000);
			system("cls");
			EnterBattle();
		}
		else if (input == '2')
		{
			PrintMessage("�κ��丮�� Ȯ���մϴ�.");
			Sleep(1000);
			showInventory();
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			cout << "���� ������ : " << player->gold << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
			Sleep(2000);
			system("cls");
			EnterDungeon();
		}
		else if (input == '3')
		{
			PrintMessage("������ �̵�");
			Sleep(1000);
			system("cls");
			EnterVillage();
		}
		else
		{
			PrintMessage("�ٽ� �Է��ϼ���");
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
			cout << "�÷��̾ ���͸� �����߽��ϴ�. " << player->atk << "�� �������� �־����ϴ�." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			monster->hp -= player->atk;
			player->PrintInfo();
			monster->PrintInfo();

			if (monster->hp <= 0)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "���͸� óġ�߽��ϴ�.������ �ٸ� ���͸� �����մϴ�." << endl;
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
			cout << "�÷��̾ ��ų�� ����� �����߽��ϴ�. " << player->Skill(player->mp) << "�� �������� �־����ϴ�." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			monster->hp -= player->Skill(player->mp);
			player->mp -= 20;
			player->PrintInfo();
			monster->PrintInfo();

			if (monster->hp <= 0)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "���͸� óġ�߽��ϴ�.������ �ٸ� ���͸� �����մϴ�." << endl;
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
			cout << "�÷��̾��� ������ �����մϴ�. �ٸ� �ൿ�� ������ �ּ���." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			PlayerTurn(player, monster);
		}
		if (input == '3')
		{
			if (player->max_hp <= player->hp)
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "�ִ� ü���Դϴ�. ������ ����� �� �����ϴ�. �ٸ� �ൿ�� ������ �ּ���." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
				PlayerTurn(player, monster);
			}
			else
			{
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "������ ��� �մϴ�." << endl;
				cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
				hpUp();
				potion.count--;
				cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
				cout << "������ " << potion.count << "�� ���ҽ��ϴ�." << endl;
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
			cout << "���Ϳ��� �������� �������ϴ�." << endl;
			cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
			Sleep(1000);
			system("cls");
			EnterDungeon();
		}		
	}

	void MonsterTurn(Player* player, Monster* monster)
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "���Ͱ� �÷��̾ �����߽��ϴ�. " << monster->atk << "�� �������� �޾ҽ��ϴ�." << endl;
		cout << "------------------------------------------------------------------------------------------------------------------------\n" << endl;
		player->hp -= monster->atk;

		if (player->hp <= 0)
		{
			GameOverScene();
		}
	}

	void EnterBattle()
	{
		// ������ ���� ����
		dungeon->CreateMonster();
		// ������ ���͸� ����
		monster = dungeon->monster;
		LevelUp();
		// ������ ����
		monster->PrintInfo();
		// �� ����
		player->PlayerBattleInfo();	
		PlayerTurn(player, monster);
	}

	void GameOverScene()
	{
		system("cls");
		PrintMessage("����ϼ̽��ϴ�. ���� ó������ ���ư��ϴ�.");
		Sleep(1000);
		OpeningScene();
	}

	void addItem()
	{
		potion.count++;
		player->gold -= potion.gold;
	}

	// �κ��丮 ���� �Լ�
	void showInventory()
	{
		cout << "------------------------------------------------------------------------------------------------------------------------" << endl;
		cout << "�κ��丮 ��� : ������ " << potion.count << "�� ���ҽ��ϴ�." << endl;
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

// ���� �Լ�
int main()
{
	// cmd�� ������ �ٲ��ش�.
	system("title TextRPG");
	// ���͸� �������� �����ϱ� ���� ����� �����Լ�
	srand((unsigned)time(0));

	Game game;
	game.Init();    // ������ �ֿ� ����� �ʱ�ȭ �ϰ����

	while (true)
	{
		game.Update();  // ������ �� �ϱ� ���� �ݺ������
	}

	return 0;
}





