using System;

namespace Task1
{
    // НЕГАТИВНЫЙ ПРИМЕР! ТАК ДЕЛАТЬ НЕЛЬЗЯ!
    class GameEntity
    {
        public string Name;
        public int Health;
        public bool CanTalk;
        public bool CanAttack;
        public bool CanMove;
        public bool HasHealth;

        public GameEntity(string name = "", int health = 0, bool canTalk = false, bool canAttack = false, bool canMove = false, bool hasHealth = false)
        {
            Name = name;
            Health = health;
            CanTalk = canTalk;
            CanAttack = canAttack;
            CanMove = canMove;
            HasHealth = hasHealth;
        }

        public void Move()
        {
            if (CanMove)
                Console.WriteLine($"{Name} is moving.");
            else
                Console.WriteLine("This entity can't move.");
        }

        public void Attack()
        {
            if (CanAttack)
                Console.WriteLine($"{Name} attacks for 10 damage!");
            else
                Console.WriteLine("This entity can't attack.");
        }

        public void Talk()
        {
            if (CanTalk)
                Console.WriteLine($"{Name} says: Hello!");
            else
                Console.WriteLine("This entity can't talk.");
        }

        public void TakeDamage(int damage)
        {
            if (HasHealth)
            {
                Health -= damage;
                Console.WriteLine($"{Name} takes {damage} damage. Health: {Health}");
                if (Health <= 0)
                    Console.WriteLine($"{Name} is dead!");
            }
            else
            {
                Console.WriteLine($"{Name} is invulnerable!");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"Can Move: {CanMove}");
            Console.WriteLine($"Can Talk: {CanTalk}");
            Console.WriteLine($"Can Attack: {CanAttack}");
            if (HasHealth)
                Console.WriteLine($"Health: {Health}");
            else
                Console.WriteLine("No Health (Invulnerable)");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация монолитного класса GameEntity ===\n");

            // Создание игрока
            var player = new GameEntity(
                name: "Player",
                health: 100,
                canTalk: true,
                canAttack: true,
                canMove: true,
                hasHealth: true
            );

            // Создание грузчика
            var loader = new GameEntity(
                name: "Loader",
                health: 0,
                canTalk: true,
                canAttack: false,
                canMove: true,
                hasHealth: false
            );

            // Создание зомби
            var zombie = new GameEntity(
                name: "Zombie",
                health: 50,
                canTalk: false,
                canAttack: true,
                canMove: true,
                hasHealth: true
            );

            // Демонстрация работы
            Console.WriteLine("1. Показ статуса всех сущностей:");
            player.ShowStatus();
            loader.ShowStatus();
            zombie.ShowStatus();

            Console.WriteLine("2. Демонстрация движения:");
            player.Move();
            loader.Move();
            zombie.Move();
            Console.WriteLine();

            Console.WriteLine("3. Демонстрация атаки:");
            player.Attack();
            loader.Attack();
            zombie.Attack();
            Console.WriteLine();

            Console.WriteLine("4. Демонстрация разговора:");
            player.Talk();
            loader.Talk();
            zombie.Talk();
            Console.WriteLine();

            Console.WriteLine("5. Демонстрация получения урона:");
            player.TakeDamage(20);
            loader.TakeDamage(20);
            zombie.TakeDamage(20);
            Console.WriteLine();

            Console.WriteLine("=== Проблемы монолитного подхода ===");
            Console.WriteLine("- Слишком много флагов для управления поведением");
            Console.WriteLine("- Сложно добавлять новые типы сущностей");
            Console.WriteLine("- Нарушение принципа единственной ответственности");
            Console.WriteLine("- Код становится нечитаемым и трудно поддерживаемым");
        }
    }
}
