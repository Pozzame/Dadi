# Dadi
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