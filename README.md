# Dadi
```mermaid
graph TD
A[Inizializzazione delle variabili] --> B[Console.Clear]
B --> C{playerUmano >= 0 && playerPC >= 0}
C -->|Sì| D[Incrementa il contatore dei lanci]
D --> E[Genera i due lanci per playerUmano]
E --> F[Console.ReadLine per lanciare i dadi]
F --> G[Console.Clear]
G --> H[Visualizza il risultato del lancio di playerUmano]
H --> I[Calcola il totale del lancio di playerUmano]
I --> J[Genera i due lanci per playerPC]
J --> K[Visualizza il risultato del lancio di playerPC]
K --> L[Calcola il totale del lancio di playerPC]
L --> M{lancioPUmano < lancioPPC}
M -->|Sì| N[Il PC vince e aggiorna playerUmano]
M -->|No| O{lancioPUmano > lancioPPC}
O -->|Sì| P[Hai vinto e aggiorna playerPC]
O -->|No| Q[Pari!]
N --> R[Visualizza il punteggio]
P --> R
Q --> R
R --> C
C -->|No| T{playerUmano < playerPC}
T -->|Sì| U[Hai perso!]
T -->|No| V[Hai vinto!]

style A fill:#f9f,stroke:#333,stroke-width:4px
style T fill:#f9f,stroke:#333,stroke-width:4px
style C fill:#bbf,stroke:#333,stroke-width:4px
style M fill:#bbf,stroke:#333,stroke-width:4px
style O fill:#bbf,stroke:#333,stroke-width:4px
```



```mermaid
flowchart LR
A[Inizializzazione delle variabili] --> B[Console.Clear]
B --> C{playerUmano >= 0 && playerPC >= 0}
C -->|Sì| D[Incrementa il contatore dei lanci]
D --> E[Genera i due lanci per playerUmano]
E --> F[Console.ReadLine per lanciare i dadi]
F --> G[Console.Clear]
G --> H[Visualizza il risultato del lancio di playerUmano]
H --> I[Calcola il totale del lancio di playerUmano]
I --> J[Genera i due lanci per playerPC]
J --> K[Visualizza il risultato del lancio di playerPC]
K --> L[Calcola il totale del lancio di playerPC]
L --> M{lancioPUmano < lancioPPC}
M -->|Sì| N[Il PC vince e aggiorna playerUmano]
M -->|No| O{lancioPUmano > lancioPPC}
O -->|Sì| P[Hai vinto e aggiorna playerPC]
O -->|No| Q[Pari!]
N --> R[Visualizza il punteggio]
P --> R
Q --> R
R --> C
C -->|No| T{playerUmano < playerPC}
T -->|Sì| U[Hai perso!]
T -->|No| V[Hai vinto!]

style A fill:#f9f,stroke:#333,stroke-width:4px
style T fill:#f9f,stroke:#333,stroke-width:4px
style C fill:#bbf,stroke:#333,stroke-width:4px
style M fill:#bbf,stroke:#333,stroke-width:4px
style O fill:#bbf,stroke:#333,stroke-width:4px
```