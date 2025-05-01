# Statistiques Tennis API

Cette API fournit des points de terminaison pour récupérer des informations sur les joueurs de tennis, y compris des statistiques sur leurs performances, tels que le pays avec le meilleur ratio de victoires, l'IMC moyen et la médiane de taille des joueurs.

## Fonctionnalités

L'API expose plusieurs points de terminaison :

- **Récupérer tous les joueurs** : `/api/players`
- **Récupérer un joueur par ID** : `/api/players/{id}`
- **Récupérer le pays avec le meilleur ratio de victoires** : `/api/players/best-win-ratio`
- **Récupérer l'IMC moyen des joueurs** : `/api/players/average-bmi`
- **Récupérer la médiane de la taille des joueurs** : `/api/players/median-height`

## Lien pour tester l'API

L'API est déployée sur Azure. Vous pouvez tester directement les différents points de terminaison en utilisant les liens suivants :

- **Récupérer tous les joueurs** :  
  [https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players](https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players)

- **Récupérer un joueur par ID** :  
  [https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/{id}](https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/{id})

- **Récupérer le pays avec le meilleur ratio de victoires** :  
  [https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/best-win-ratio](https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/best-win-ratio)

- **Récupérer l'IMC moyen des joueurs** :  
  [https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/average-bmi](https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/average-bmi)

- **Récupérer la médiane de la taille des joueurs** :  
  [https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/median-height](https://statistiques-tennis-fcc3hqfve6fzeke9.canadacentral-01.azurewebsites.net/api/players/median-height)

## Prérequis

Pour faire fonctionner ce projet en local, vous devez disposer des outils suivants :

### .NET 8

Le projet utilise la version 8 de .NET pour le développement.  
Téléchargez et installez .NET 8 depuis [ici](https://dotnet.microsoft.com/download/dotnet/8.0).

### Azure

Vous devez avoir un compte Azure pour déployer l'application sur Azure App Services.  
Créez un compte Azure et configurez votre instance Azure App Service pour le déploiement.

### SonarCloud

Le projet utilise SonarCloud pour l'analyse statique du code, la couverture des tests unitaires et la qualité du code.  
Créez un compte sur [SonarCloud](https://sonarcloud.io/) et générez un **SONAR_TOKEN**.

## Déploiement

### Ajouter un profil de publication Azure

Pour faciliter le déploiement via **GitHub Actions**, téléchargez le **Publish Profile** depuis le portail Azure et ajoutez-le aux secrets GitHub sous la variable **`AZURE_PUBLISH_PROFILE`**.

### Variables GitHub Actions

Afin d'assurer le bon fonctionnement du pipeline CI/CD, vous devez ajouter les variables suivantes dans les **GitHub Secrets** :

- **`SONAR_TOKEN`** : Token SonarCloud pour l'analyse du code.
- **`GITHUB_TOKEN`** : Token généré automatiquement pour GitHub Actions.
- **`AZURE_PUBLISH_PROFILE`** : Profil de publication Azure téléchargé depuis le portail Azure.

## CI/CD avec GitHub Actions

Le projet utilise **GitHub Actions** pour automatiser le processus de build, d'analyse de code et de déploiement.

### Déclencheurs

Le pipeline GitHub Actions est déclenché par les événements suivants :

- **Push** sur la branche `master`.
- **Pull Request** vers la branche `master`.
- **Manuel** via `workflow_dispatch`.

## Questions

Si vous avez des questions ou avez besoin de précisions supplémentaires, n'hésitez pas à me contacter via [https://craftedcode.fr/](https://craftedcode.fr/).

