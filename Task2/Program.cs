using System;

namespace Task2
{
    // Базовый класс для всех игровых сущностей
    public abstract class GameEntity
    {
        public virtual void ShowStatus()
        {
            Console.WriteLine("=== Game Entity ===");
        }
    }

    // Класс для сущностей, которые могут двигаться
    public abstract class MovableEntity : GameEntity
    {
        public virtual void Move()
        {
            Console.WriteLine("Entity is moving.");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("Can Move: Yes");
        }
    }

    // Класс для сущностей с здоровьем
    public abstract class HealthEntity : MovableEntity
    {
        public int Health { get; set; }

        public HealthEntity(int health)
        {
            Health = health;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Takes {damage} damage. Health: {Health}");
            if (Health <= 0)
                Console.WriteLine("Entity is dead!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine($"Health: {Health}");
        }
    }

    // Класс для сущностей, которые могут говорить
    public abstract class TalkableEntity : MovableEntity
    {
        public string Name { get; set; }

        public TalkableEntity(string name)
        {
            Name = name;
        }

        public virtual void Talk()
        {
            Console.WriteLine($"{Name} says: Hello!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine("Can Talk: Yes");
        }
    }

    // Класс для сущностей, которые могут атаковать
    public abstract class AttackingEntity : MovableEntity
    {
        public virtual void Attack()
        {
            Console.WriteLine("Entity attacks for 10 damage!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("Can Attack: Yes");
        }
    }

    // Игрок - может говорить, атаковать и имеет здоровье
    public class Player : TalkableEntity
    {
        public int Health { get; set; }

        public Player(string name, int health) : base(name)
        {
            Health = health;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} attacks for 10 damage!");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Health: {Health}");
            if (Health <= 0)
                Console.WriteLine($"{Name} is dead!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine("Can Attack: Yes");
        }
    }

    // Грузчик - может говорить, но не атакует и не имеет здоровья
    public class Loader : TalkableEntity
    {
        public Loader(string name) : base(name)
        {
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("Can Attack: No");
            Console.WriteLine("Health: No (Invulnerable)");
        }
    }

    // Зомби - может атаковать и имеет здоровье, но не говорит
    public class Zombie : AttackingEntity
    {
        public int Health { get; set; }

        public Zombie(int health)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Zombie takes {damage} damage. Health: {Health}");
            if (Health <= 0)
                Console.WriteLine("Zombie is dead!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine("Can Talk: No");
        }
    }

    // Проблемный случай: Коробка - имеет здоровье, но не может говорить, атаковать или двигаться
    public class Box : GameEntity
    {
        public int Health { get; set; }

        public Box(int health)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Box takes {damage} damage. Health: {Health}");
            if (Health <= 0)
                Console.WriteLine("Box is destroyed!");
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("Can Move: No");
            Console.WriteLine("Can Talk: No");
            Console.WriteLine("Can Attack: No");
            Console.WriteLine($"Health: {Health}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация иерархии наследования ===\n");

            // Создание экземпляров
            var player = new Player("Player", 100);
            var loader = new Loader("Loader");
            var zombie = new Zombie(50);
            var box = new Box(30);

            // Демонстрация работы
            Console.WriteLine("1. Показ статуса всех сущностей:");
            player.ShowStatus();
            Console.WriteLine();
            loader.ShowStatus();
            Console.WriteLine();
            zombie.ShowStatus();
            Console.WriteLine();
            box.ShowStatus();
            Console.WriteLine();

            Console.WriteLine("2. Демонстрация движения:");
            player.Move();
            loader.Move();
            zombie.Move();
            // box.Move(); // Ошибка компиляции - Box не наследует от MovableEntity
            Console.WriteLine();

            Console.WriteLine("3. Демонстрация атаки:");
            player.Attack();
            // loader.Attack(); // Ошибка компиляции - Loader не наследует от AttackingEntity
            zombie.Attack();
            // box.Attack(); // Ошибка компиляции - Box не наследует от AttackingEntity
            Console.WriteLine();

            Console.WriteLine("4. Демонстрация разговора:");
            player.Talk();
            loader.Talk();
            // zombie.Talk(); // Ошибка компиляции - Zombie не наследует от TalkableEntity
            // box.Talk(); // Ошибка компиляции - Box не наследует от TalkableEntity
            Console.WriteLine();

            Console.WriteLine("5. Демонстрация получения урона:");
            player.TakeDamage(20);
            // loader.TakeDamage(20); // Ошибка компиляции - Loader не имеет метода TakeDamage
            zombie.TakeDamage(20);
            box.TakeDamage(20);
            Console.WriteLine();

            Console.WriteLine("=== Проблемы иерархии наследования ===");
            Console.WriteLine("- Сложно создать идеальную иерархию без дублирования кода");
            Console.WriteLine("- Проблема 'Алмаз смерти' при множественном наследовании");
            Console.WriteLine("- Некоторые сущности (как Box) не вписываются в иерархию");
            Console.WriteLine("- Дублирование кода (метод TakeDamage в Player и Zombie)");
            Console.WriteLine("- Неочевидность логики и сложность понимания иерархии");
        }
    }
}
