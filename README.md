# Dadi
```mermaid
flowchart TD
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

```mermaid
flowchart TD
    A[Start] --> B[Initialize variables]
    B --> C{File exists?}
    C --> |Yes| D[Load game state from file]
    D --> F[Clear console]
    C --> |No| E[Create and initialize file]
    E --> F[Clear console]

    F --> G{Nobody wins yet?}
    G --> |Yes| H[Display launch number]
    H --> I[Human launches dice]
    I --> J[Display human dice results]
    J --> K[PC launches dice]
    K --> L[Display PC dice results]
    L --> M{Compare dice results}
    M --> |PC wins| N[Display PC won]
    N --> O[Reduce playerHuman score]
    M --> |Human wins| P[Display You won]
    P --> Q[Reduce playerPC score]
    M --> |Even| R[Display Even]
    
    O --> S[Save game state to file]
    Q --> S
    R --> S

    S --> T[Display score bar chart]
    T --> G

    G --> |No| U{PC won?}
    U --> |Yes| V[Display final score You lost]
    V --> W[Update PC win count]
    U --> |No| X[Display final score You won]
    X --> Y[Update human win count]

    W --> Z[Reset game state and save to file]
    Y --> Z
    Z --> AA[Display total wins]
    AA --> AB[End]
```