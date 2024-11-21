package com.example.descubrelasestaciones

import android.app.Service
import android.content.Intent
import android.media.MediaPlayer
import android.os.IBinder


class BackgroundSound : Service() {
    private lateinit var mediaPlayer: MediaPlayer

    override fun onCreate() {
        super.onCreate()
        mediaPlayer =
            MediaPlayer.create(this, R.raw.musicafondo) // Agrega tu archivo de audio en res/raw
        mediaPlayer.isLooping = true // Repetir audio
        mediaPlayer.setVolume(1.0f, 1.0f)
    }

    override fun onStartCommand(intent: Intent, flags: Int, startId: Int): Int {
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
