# Dadi
```mermaid
flowchart LR
    A[Inizializzazione variabili] --> B[Console.Clear]
    B --> C{Gioca finché uno non perde}
    C -->|Sì| D[Chiedi di lanciare all'utente]
    D --> E[Fai il lancio del PC]
    E --> F[Visualizza lanci e calcola totali dei lanci]
    F --> G{Confronta i lanci}
    G -->|PC vince| H[Il PC vince e aggiorna punti]
    G -->|Giocatore vince| I[Hai vinto e aggiorna punti]
    G -->|Pari| J[Pari!]
    H --> K[Visualizza punteggio turno]
    I --> K
    J --> K
    K --> C
    C -->|No| M{PC ha vinto?}
    M -->|Sì| N[Hai perso!]
    M -->|No| O[Hai vinto!]

    style A fill:#f9f,stroke:#333,stroke-width:2px
    style M fill:#bbf,stroke:#333,stroke-width:2px
    style C fill:#bbf,stroke:#333,stroke-width:2px
    style G fill:#bbf,stroke:#333,stroke-width:2px
```