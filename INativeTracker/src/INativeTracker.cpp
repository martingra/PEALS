// Archivo DLL principal.

#include <Windows.h>
#include "INativeTracker.h"
#include <opencv2/highgui/highgui.hpp>
#include <string>
#include <fstream>
#include <iostream>

using namespace std;

using namespace tld;
using namespace cmt;
using namespace cv;

TLD *_tld;
CMT *_cmt;

/****************************** TLD *************************************/
EXPORT_API void _tld_release(){ _tld->release(); }

EXPORT_API void _tld_selectObject(const IplImage *imgArr, cv::Rect *bb)
{
	_tld = new TLD();

	Mat img = cvarrToMat(imgArr, true);
	_tld->detectorCascade->imgWidth = img.cols;
    _tld->detectorCascade->imgHeight = img.rows;
    _tld->detectorCascade->imgWidthStep = img.step;

	_tld->selectObject(img, bb);

	//cvReleaseImage(&imgArr);
}

EXPORT_API void _tld_processImage(const IplImage *imgArr)
{
	Mat img = cvarrToMat(imgArr, true);
	_tld->processImage(img);

	//cvReleaseImage(&imgArr);
}

EXPORT_API void _tld3_selectObject(const cv::Mat *img, cv::Rect *bb)
{
	_tld = new TLD();

	_tld->detectorCascade->imgWidth = img->cols;
    _tld->detectorCascade->imgHeight = img->rows;
    _tld->detectorCascade->imgWidthStep = img->step;

	_tld->selectObject(*img, bb);
}

EXPORT_API void _tld3_processImage(const cv::Mat *img)
{
	_tld->processImage(*img);
}

EXPORT_API cv::Rect* _tld_getROI(){ return _tld->currBB; }

EXPORT_API float _tld_getCurrConfident(){ return _tld->currConf; }

EXPORT_API bool _tld_isLearning(){ return _tld->learning; }

EXPORT_API void _tld_writeToFile(const char *path){ _tld->writeToFile(path); }

EXPORT_API void _tld_readFromFile(const char *path){ _tld->readFromFile(path); }

/**************************** END TLD ***********************************/

/****************************** CMT *************************************/

EXPORT_API int _cmt_initialize(IplImage *imgArr, cv::Rect *rect, bool estimate_rotation, bool estimate_scale, const char* detector)
{
	_cmt = new CMT();
	_cmt->str_detector = detector;

	_cmt->consensus.estimate_rotation = estimate_rotation;
	_cmt->consensus.estimate_scale = estimate_scale;

	Mat gray = cvarrToMat(imgArr, true);

	_cmt->initialize(gray, rect);

	return gray.rows;
}

EXPORT_API int _cmt_processFrame(IplImage *imgArr)
{
	Mat gray = cvarrToMat(imgArr, true);
	_cmt->processFrame(gray);

	return gray.rows;
}

EXPORT_API const Rect _cmt_getROI()
{ 
	int* values = new int[4];	
	values[0] = _cmt->bb_rot.boundingRect().x;
	values[1] = _cmt->bb_rot.boundingRect().y;
	values[2] = _cmt->bb_rot.boundingRect().width;
	values[3] = _cmt->bb_rot.boundingRect().height;

	cv::Rect *rect = &(tldArrayToRect(values));
	return _cmt->bb_rot.boundingRect();
}

EXPORT_API float* _cmt_getRotatedROI()
{
	float* values = new float[5];	
	values[0] = _cmt->bb_rot.angle;
	values[1] = _cmt->bb_rot.center.x;
	values[2] = _cmt->bb_rot.center.y;
	values[3] = _cmt->bb_rot.size.width;
	values[4] = _cmt->bb_rot.size.height;

	return values;
}

EXPORT_API int _cmt_getPointsCounts()
{
	return _cmt->points_active.size();
}

EXPORT_API float* _cmt_getPoints()
{
	int total = _cmt->points_active.size();
	float* points = new float[total*2];
	for (int i= 0; i< total; i++)
	{
		points[i*2] = _cmt->points_active[i].x;
		points[(i*2)+1] = _cmt->points_active[i].y;
	}

	return points;
}

/**************************** END CMT ***********************************/