package com.example.descubrelasestaciones

import android.view.View
import android.view.View.DragShadowBuilder

class CustomDragShadowBuilder(view: View) : DragShadowBuilder(view) {
    override fun onProvideShadowMetrics(outMetrics: android.graphics.Point, outShadow: android.graphics.Point) {
        super.onProvideShadowMetrics(outMetrics, outShadow)
        outMetrics.set(300, 300) // Ajusta el tamaño de la sombra
        outShadow.set(50, 50) // Ajusta el tamaño del objeto arrastrado
    }
}