# SurvivalProject_Unity

Le jeu comporte deux scenes. La scene MainMenu fonctionne, avec le bouton Start le jeu starts.

1. Patron SingleTon: pour rendre les scripts accessibles :GameController, objectPoll, Player, PlayerSkills
2. Patron ObjectPool: Pour contrôler l'activation et la désactivation de ces gameObjects: ObjectPool, CrystalPools et BloodEffectPool
3. Patron Observer: MainMenu, GameOver
4. Patron Factory: EnemyFactory
5. Progression Gamplay: À chaque 5 levels, le Player fait Upgrade pour les armes et dans chaque Wave d'enemie les enemies faisant le Upgrade de HP et de quantité d'enemie par Wave. 
