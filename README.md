# Publicar el proyecto en GitHub

Sigue estos pasos para inicializar Git y subir el proyecto a GitHub. Este repositorio incluye un `.gitignore` para .NET, Visual Studio y JetBrains Rider.

## Opción A: Usando JetBrains Rider (recomendado si ya trabajas en JetBrains)

1) Verifica que Git está habilitado:
   - VCS -> Enable Version Control Integration... -> Selecciona "Git".

2) Realiza el primer commit:
   - VCS -> Commit...
   - Revisa los cambios, escribe un mensaje (por ejemplo: "Initial commit") y pulsa "Commit" (o "Commit and Push" si ya tienes el remoto creado).

3) Comparte el proyecto en GitHub:
   - VCS -> Import into Version Control -> Share Project on GitHub
     (en versiones recientes: Git -> GitHub -> Share Project on GitHub).
   - Inicia sesión si te lo pide.
   - Elige nombre del repositorio, visibilidad (Privado/Público) y confirma con "Share".

4) Verifica el remoto:
   - VCS -> Git -> Remotes... y comprueba que existe `origin` apuntando a tu repo en GitHub.

5) Sube cambios futuros:
   - VCS -> Commit... -> "Commit and Push" o
   - VCS -> Git -> Push...

## Opción B: Usando la línea de comandos (CLI)

Prerrequisitos: tener Git instalado y una cuenta en GitHub.

1) Inicializa el repositorio local:
