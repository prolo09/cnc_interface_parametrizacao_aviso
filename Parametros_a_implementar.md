# Parâmetros a implementar

## Tab1 - Parametros gerais

- Sistema de unidades
- Jog Units Mode
    * Follow units mode / inch / metric


## Eixos

- Tipo de máquina
    * Fresa  / laser/ (Torno?)
    - X
        - Enabled [Y/N]
        - Tipo de eixo (linear)
        - Passo
        - velo. Rot. Max (max pulsos que o stepper motor aceita)
        - ID Motor (v2)
        - G00 feed (= vel.rot.max * passo)
        - G01 max feed (= 0.6 * G00.feed)
        - jog max feed (= 0.2 * G00.feed)
        - limite - (=0)
        - limite + (=comprimento)
        - encoder / regua otica / stepper motor
            + pitch
            + n pulsos
    - Y 
        - (igual ao eixo x)
    - Z
        - (igual ao eixo x)
    - Spindle (se fresa)
        - vel. Rot. Max
        - ID Motor (v2)
        - constant rpm
        - wait on spindle to stabilize to n % (v2)
    - Laser (se laser)
        - Potencia

## Tools
- tabela:
    - linhas: pocket n
    - colunas: pocket / tool no. / L / D


- Permite troca de ferramenta [Y/N]
- Nº pockets
- nº ferramentas
- tipo de armazém (fixo/aleatório)
- Max tools (1)
- Tool change type
    * T M6 line is next tool
    * T on M6 line is tool to use
- Tool life cancel number
-  tool life restart M code
- Tool life type defaut
    * cycle
    * time
- tool skip group
    * current group
    * specified
- tool exchange reset signal
    * clears specified group
    * clears all groups
- life count override (time only)
    * disabled
    * enabled
- M99 expired condition
    * TLCHB signal is not output
    * TLCHB signal is output
- TLCHB signal
    * output for each tool
    * output for the last tool in a group

## Comunicação

- Porta COM
- Baudrate (?)
- Protocolo (?)
- endereço IP

## G-Code

- Unidades
- Start code (v2)
- End Code (v2)
- Feed Mode (per minute)


***
## Parametros segundo o programa Mach4
### Default

- Tranverse Mode
    * rapid / feed
- Motion Mode
    * Constant Velocity / exact Stop
- Distance Mode
    * Absolute / incremental
- Arc center Mode
    * Absolute / Incremental
- Active Plane
    * xy / yz / xz
- Cycle retract
    * initial Z / rapid plane

### General

- Delay
	* Coolant Delay
	* mist delay
- SETVN Range
	* Start
	* End
- Look ahead lines
- Jog increments
- G code file extensions
- G code file editor 
- Misc

### Axis Mapping

- Table:
	* Rows: axis
	* Columns:/ master / slave

### Homing/soft limits

- Table:
    * Row: axis
    * Columns: home dir / home order /home offset / home speed% / home in place / soft enable / soft min / soft max

### Input signals

- Table:
    * Row: input #n
    * column: Mapping enabled / Device / Input name / active Low / user description

### Output signals

- Table:
    * row: x++ / x-- / x home / y++ ...
    * column: Mapping enabled 7 device / Output name / Active low / user description

### MPGs (v2)

- Table: 
    * row: Mpg #n
    * column: Enabled / encoder / counts per detent / accel % / velocity % / reversed



### spindle

- spindle override delay (ms)
- Step/dir spindle axis: 
    * none
    * OB1
    * OB...n
-enable step/dir spindle rigid tapping

### Tool path

- tool path default options
    * disable vbo tool path?
    * use a frame to draw the tool path?
    * use Lazy toll path update
    * Display a axis rotation: 
        - Rotate around x
        - rotate around y
        - rotate around z
        - no rotation
