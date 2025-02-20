# CS2_JoinSound

CS2_JoinSound — это плагин, который воспроизводит звук, когда игрок полностью подключается к серверу.

## Команды

- `jtest` - Воспроизводит музыкальный файл для теста.

## Конфигурация

Конфигурация плагина хранится в файле `CS2_JoinSound.json`. В этом файле вы можете настроить путь к музыкальному файлу, который будет воспроизводиться при подключении игрока.

Пример конфигурации:

```json
{
  "soundMode": "order", // по очереди или рандомно
  "musicList": [
    {
      "path": "dpmusic3/d1.vsnd"
    },
    {
      "path": "dpmusic3/d2.vsnd"
    }
  ],
  "ConfigVersion": 1
}
```
## Требования

- **[CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)**
- **[MultiAddonManager](https://github.com/Source2ZE/MultiAddonManager)**

### todo

- ~~воспроизводить треки рандомно или по очереди~~

- использовать SoundEvent вместо play
