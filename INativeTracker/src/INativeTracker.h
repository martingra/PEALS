// INativeTracker.h

#ifndef __TLDDLL_H__
#define __TLDDLL_H__

#include <Windows.h>
#include "tld\TLD.h"
#include "tld\TLDUtil.h"
#include "cmt\CMT.h"

#ifndef TLDDLL_EXPORTS
#define EXPORT_API __declspec(dllexport)
#else
#define EXPORT_API __declspec(dllimport)
#endif

extern "C"{
	/**************************** TLD METHODS *****************************/
	EXPORT_API void _tld_release();
	
	// Usados en emgu 2.4
	EXPORT_API void _tld_selectObject(const IplImage *imgArr, cv::Rect *bb);
    EXPORT_API void _tld_processImage(const IplImage *imgArr);

	// Usados en emgu 3.0
	EXPORT_API void _tld3_selectObject(const cv::Mat *img, cv::Rect *bb);
    EXPORT_API void _tld3_processImage(const cv::Mat *img);

	EXPORT_API cv::Rect* _tld_getROI();
	EXPORT_API float _tld_getCurrConfident();
	EXPORT_API bool _tld_isLearning();

    EXPORT_API void _tld_writeToFile(const char *path);
    EXPORT_API void _tld_readFromFile(const char *path);
	/************************** END TLD METHODS *****************************/

	/**************************** CMT METHODS *****************************/
	EXPORT_API int _cmt_initialize(IplImage *imgArr, cv::Rect *rect, bool estimate_rotation, bool estimate_scale, const char* detector);
    EXPORT_API int _cmt_processFrame(IplImage *imgArr);
	EXPORT_API const Rect _cmt_getROI();
	EXPORT_API float* _cmt_getRotatedROI();
	EXPORT_API int _cmt_getPointsCounts();
	EXPORT_API float* _cmt_getPoints();
	/************************** END CMT METHODS *****************************/
}
#endif //__TLDDLL_H__
