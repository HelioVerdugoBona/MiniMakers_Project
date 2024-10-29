package com.example.descubrelasestaciones

import android.view.View
import android.view.View.DragShadowBuilder

class CustomDragShadowBuilder(view: View) : DragShadowBuilder(view) {
    override fun onProvideShadowMetrics(outMetrics: android.graphics.Point, outShadow: android.graphics.Point) {
        super.onProvideShadowMetrics(outMetrics, outShadow)
        outMetrics.set(500, 500) // Ajusta el tamaño de la sombra
        outShadow.set(180, 180) // Ajusta el tamaño del objeto arrastrado
    }
}