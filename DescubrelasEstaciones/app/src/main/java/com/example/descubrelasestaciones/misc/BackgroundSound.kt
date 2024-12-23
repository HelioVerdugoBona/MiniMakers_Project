package com.example.descubrelasestaciones.misc

import android.app.Service
import android.content.Intent
import android.media.MediaPlayer
import android.os.IBinder
import com.example.descubrelasestaciones.R


class BackgroundSound : Service() {
    private lateinit var mediaPlayer: MediaPlayer

    override fun onCreate() {
        super.onCreate()
        mediaPlayer =
            MediaPlayer.create(this, R.raw.musicafondo)
        mediaPlayer.isLooping = true // Repetir audio
        mediaPlayer.setVolume(0.5f, 0.5f)
    }

    override fun onStartCommand(intent: Intent?, flags: Int, startId: Int): Int {
        if (intent == null) {
            // Manejar caso nulo, opcionalmente puedes registrar un log
            return START_STICKY
        }

        if (!mediaPlayer.isPlaying) {
            mediaPlayer.start()
        }
        return START_STICKY
    }


    override fun onDestroy() {
        if (mediaPlayer != null) {
            mediaPlayer.stop()
            mediaPlayer.release()
        }
        super.onDestroy()
    }

    override fun onBind(intent: Intent): IBinder? {
        return null // No usamos bound services aquí
    }
}
