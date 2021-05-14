using Godot;

public class Stats : Node
{
    [Export] public float MaxHealth = 5;
    [Export] public float Health = 0;
    [Export] public float MaxMana { get; set; }
    [Export] public float Mana { get; set; }
    [Export] public int MaxMoney { get; set; }
    [Export] public int Money { get; set; }
    [Export] public int Scores { get; set; }

    public TextureProgress HealthProgress = new TextureProgress();
    public TextureProgress ManaProgress = new TextureProgress();

    public Label HealthLabel = new Label();
    public Label ManaLabel = new Label();
    public Label ScoresLabel = new Label();
    public Label CoinLabel = new Label();
    public override void _Ready()
    {
        ManaProgress = GetNodeOrNull<TextureProgress>("/root/Core/Game/UI/VBoxContainer/ManapointBar");
        ManaLabel = ManaProgress.GetNodeOrNull<Label>("ManaLabel");
        MaxMana = 5;
        Mana = MaxMana;
        ManaProgress.MaxValue = MaxMana;
        ManaProgress.MinValue = 0;
        ManaProgress.Step = 0.1f;
        ManaLabel.Text = $"{Mana}/{MaxMana}";

        HealthLabel = GetNodeOrNull<Label>("/root/Core/Game/UI/VBoxContainer/HealthBar/LifeLabel");
        HealthProgress = GetNodeOrNull<TextureProgress>("/root/Core/Game/UI/VBoxContainer/HealthBar");
        MaxHealth = 5;
        Health = MaxHealth;
        HealthProgress.MinValue = 0;
        HealthProgress.MaxValue = MaxHealth;
        HealthLabel.Text = $"{Health}/{MaxHealth}";

        MaxMoney = 10000;
        Money = 0;
        CoinLabel = GetNodeOrNull<Label>("/root/Core/Game/UI/CoinsContainer/Coins");
        CoinLabel.Text = $"{Money}";

        Scores = 0;
        ScoresLabel = GetNodeOrNull<Label>("/root/Core/Game/UI/ScoresContainer/Scores");
        ScoresLabel.Text = $"Scores: {Scores}";

    }
    public void ManaDrain(float mana)
    {
        if (Mana == 0)
        {
            return;
        }

        Mana -= Mathf.Stepify(mana, 0.01f);
        ManaProgress.Value -= mana;
        ManaLabel.Text = $"{Mathf.Stepify(Mana, 0.01f)}/{MaxMana}";
    }

    public void ManaApply(float mana)
    {
        if (Mana + mana >= MaxMana)
        {
            Mana = Mathf.Stepify(MaxMana, 0.01f);
        }
        else
        {
            Mana += Mathf.Stepify(mana, 0.01f);
        }
        ManaProgress.Value = Mana;
        ManaLabel.Text = $"{Mathf.Stepify(Mana, 0.01f)}/{MaxMana}";
    }
    public void GetMoney(int money)
    {
        if (Money + money > MaxMoney)
        {
            Money = MaxMoney;
        }
        else if (Money + money <= MaxMoney)
        {
            Money += money;
        }

        CoinLabel.Text = $"{Money}";
    }
    public bool PayMoney(int money)
    {
        if (Money - money < 0)
        {
            return false;
        }
        else if (Money - money >= 0)
        {
            Money -= money;
        }

        CoinLabel.Text = $"{Money}";
        return true;
    }

    public void GetHealth(float health)
    {
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        else if (Health < MaxHealth)
        {
            Health += health;
        }

        HealthProgress.Value = Health;
        HealthLabel.Text = $"{Mathf.Stepify(Health, 0.01f)}/{MaxHealth}";
    }

    public void TakeHealth(int health)
    {
        Health -= health;
        HealthProgress.Value = Health;
        HealthLabel.Text = $"{Mathf.Stepify(Health, 0.01f)}/{MaxHealth}";
    }


    public void GetScores(int scores)
    {
        Scores += scores;
        ScoresLabel.Text = $"Scores: {Scores}";
    }
}
