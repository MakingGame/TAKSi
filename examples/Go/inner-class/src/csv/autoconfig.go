// This file is auto-generated by TAKSi v1.1.0, DO NOT EDIT!

package config

import (
	"encoding/csv"
	"io"
	"strings"
)

var (
	_ = io.EOF
	_ = strings.Compare
)

const (
	KeyBoxProbabilityDefineName = "box_probability_define"
)

type ProbabilityGoodsDefine struct {
	GoodsID     string // 物品1id
	Num         uint32 // 物品1数量
	Probability uint32 // 物品1概率
}

// , 随机宝箱.xlsx
type BoxProbabilityDefine struct {
	ID               string                   // ID
	Total            int                      // 奖励总数
	Time             int                      // 冷却时间
	Repeat           bool                     // 是否可重复
	ProbabilityGoods []ProbabilityGoodsDefine //
}

func (p *BoxProbabilityDefine) ParseFromRow(row []string) error {
	if len(row) < 13 {
		log.Panicf("BoxProbabilityDefine: row length out of index %d", len(row))
	}
	if row[0] != "" {
		p.ID = row[0]
	}
	if row[1] != "" {
		var value = MustParseTextValue("int", row[1], row)
		p.Total = value.(int)
	}
	if row[2] != "" {
		var value = MustParseTextValue("int", row[2], row)
		p.Time = value.(int)
	}
	if row[3] != "" {
		var value = MustParseTextValue("bool", row[3], row)
		p.Repeat = value.(bool)
	}
	for i := 4; i < 13; i += 3 {
		var item ProbabilityGoodsDefine
		if row[i+0] != "" {
			item.GoodsID = row[i+0]
		}
		if row[i+1] != "" {
			var value = MustParseTextValue("uint32", row[i+1], row)
			item.Num = value.(uint32)
		}
		if row[i+2] != "" {
			var value = MustParseTextValue("uint32", row[i+2], row)
			item.Probability = value.(uint32)
		}
		p.ProbabilityGoods = append(p.ProbabilityGoods, item)
	}
	return nil
}

func LoadBoxProbabilityDefineList(loader DataSourceLoader) ([]*BoxProbabilityDefine, error) {
	buf, err := loader.LoadDataByKey(KeyBoxProbabilityDefineName)
	if err != nil {
		return nil, err
	}
	var list []*BoxProbabilityDefine
	var r = csv.NewReader(buf)
	for i := 0; ; i++ {
		row, err := r.Read()
		if err == io.EOF {
			break
		}
		if err != nil {
			log.Errorf("BoxProbabilityDefine: read csv %v", err)
			return nil, err
		}
		var item BoxProbabilityDefine
		if err := item.ParseFromRow(row); err != nil {
			log.Errorf("BoxProbabilityDefine: parse row %d, %s, %v", i+1, row, err)
			return nil, err
		}
		list = append(list, &item)
	}
	return list, nil
}
